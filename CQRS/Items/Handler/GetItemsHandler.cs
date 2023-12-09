using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApi.CQRS.Items.Queries;
using TestApi.Models;

namespace TestApi.CQRS.Items.Handler
{
    public class GetItemsHandler : IRequestHandler<GetItemsQuery, List<Item>>
    {
        private readonly Context _context;

        public GetItemsHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<Item>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _context.Items.ToListAsync());
        }
    }
}
