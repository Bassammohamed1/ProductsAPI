using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestApi.CQRS.Categories.Commands;
using TestApi.CQRS.Categories.Queries;
using TestApi.CQRS.Items.Commands;
using TestApi.CQRS.Items.Queries;
using TestApi.DTOS;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class ItemsController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMediator _mediatR;

        public ItemsController(Context context, IMediator mediatR)
        {
            _context = context;
            _mediatR = mediatR;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllItems()
        {
            var result = await _mediatR.Send(new GetItemsQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetItemById([FromRoute] int id)
        {
            var result = await _mediatR.Send(new GetItemByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> InsertCategory(Itemdto data)
        {
            var result = await _mediatR.Send(new InsertItemCommand(data));
            return Ok(result);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(Item data)
        {
            var result = await _mediatR.Send(new UpdateItemCommand(data));
            return Ok(result);
        }
        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PatchCategory([FromBody] JsonPatchDocument<Item> data, [FromRoute] int id)
        {
            var result = await _context.Items.FindAsync(id);
            if (result == null)
                return BadRequest("Id is invalid");
            data.ApplyTo(result);
            _context.SaveChanges();
            return Ok(result);
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var data = _context.Items.Find(id);
            var result = await _mediatR.Send(new DeleteItemCommand(data));
            return Ok(result);
        }
    }
}