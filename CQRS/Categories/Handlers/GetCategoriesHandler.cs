using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApi.CQRS.Categories.Queries;
using TestApi.Models;

namespace TestApi.CQRS.Categories.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly Context _context;

        public GetCategoriesHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _context.Categories.ToListAsync());
        }
    }
}
