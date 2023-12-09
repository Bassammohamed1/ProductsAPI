using MediatR;
using TestApi.CQRS.Categories.Commands;
using TestApi.Models;

namespace TestApi.CQRS.Categories.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {
        private readonly Context _context;

        public DeleteCategoryHandler(Context context)
        {
            _context = context;
        }

        public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            _context.Categories.Remove(request.data);
            _context.SaveChanges();
            return await Task.FromResult(request.data);
        }
    }
}
