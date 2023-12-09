using MediatR;
using TestApi.CQRS.Categories.Commands;
using TestApi.Models;

namespace TestApi.CQRS.Categories.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly Context _context;

        public UpdateCategoryHandler(Context context)
        {
            _context = context;
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            _context.Categories.Update(request.data);
            _context.SaveChanges();
            return await Task.FromResult(request.data);
        }
    }
}
