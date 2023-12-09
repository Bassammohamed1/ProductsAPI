using MediatR;
using TestApi.CQRS.Items.Commands;
using TestApi.Models;

namespace TestApi.CQRS.Items.Handler
{
    public class InsertItemHandler : IRequestHandler<InsertItemCommand, Item>
    {
        private readonly Context _context;

        public InsertItemHandler(Context context)
        {
            _context = context;
        }

        public async Task<Item> Handle(InsertItemCommand request, CancellationToken cancellationToken)
        {
            var result = new Item() { Name = request.data.Name, CategoryId = request.data.CategoryId };
            await _context.AddAsync(result);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result);
        }
    }
}
