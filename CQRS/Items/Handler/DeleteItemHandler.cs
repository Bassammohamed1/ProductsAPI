using MediatR;
using TestApi.CQRS.Items.Commands;
using TestApi.Models;

namespace TestApi.CQRS.Items.Handler
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, Item>
    {
        private readonly Context _context;

        public DeleteItemHandler(Context context)
        {
            _context = context;
        }

        public async Task<Item> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            _context.Items.Remove(request.data);
            _context.SaveChanges();
            return await Task.FromResult(request.data);
        }
    }
}
