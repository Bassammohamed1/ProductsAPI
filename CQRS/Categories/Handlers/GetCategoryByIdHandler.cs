using MediatR;
using TestApi.CQRS.Categories.Queries;
using TestApi.Models;

namespace TestApi.CQRS.Categories.Handlers
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly Context _context;

        public GetCategoryByIdHandler(Context context)
        {
            _context = context;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _context.Categories.FindAsync(request.id));
        }
    }
}
