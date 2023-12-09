using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestApi.CQRS.Categories.Commands;
using TestApi.CQRS.Categories.Queries;
using TestApi.CQRS.Items.Commands;
using TestApi.DTOS;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMediator _mediatR;

        public CategoriesController(Context context, IMediator mediatR)
        {
            _context = context;
            _mediatR = mediatR;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _mediatR.Send(new GetCategoriesQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var result = await _mediatR.Send(new GetCategoryByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> InsertCategory(Categorydto data)
        {
            var result = await _mediatR.Send(new InsertCategoryCommand(data));
            return Ok(result);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(Category data)
        {
            var result = await _mediatR.Send(new UpdateCategoryCommand(data));
            return Ok(result);
        }
        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PatchCategory([FromBody] JsonPatchDocument<Category> data, [FromRoute] int id)
        {
            var result = await _context.Categories.FindAsync(id);
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
            var data = _context.Categories.Find(id);
            var result = await _mediatR.Send(new DeleteCategoryCommand(data));
            return Ok(result);
        }
    }
}
