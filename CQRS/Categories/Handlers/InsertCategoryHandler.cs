using MediatR;
using TestApi.CQRS.Categories.Commands;
using TestApi.Models;

namespace TestApi.CQRS.Categories.Handlers
{
    public class InsertCategoryHandler : IRequestHandler<InsertCategoryCommand, Category>
    {
        private readonly Context _context;

        public InsertCategoryHandler(Context context)
        {
            _context = context;
        }

        public async Task<Category> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = new Category() { Name = request.data.Name };
            await _context.Categories.AddAsync(result);
            _context.SaveChanges();
            return await Task.FromResult(result);
        }
    }
}
