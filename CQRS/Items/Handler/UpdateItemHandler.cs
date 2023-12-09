using MediatR;
using TestApi.CQRS.Items.Commands;
using TestApi.Models;

namespace TestApi.CQRS.Items.Handler
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, Item>
    {
        private readonly Context _context;

        public UpdateItemHandler(Context context)
        {
            _context = context;
        }

        public async Task<Item> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            _context.Items.Update(request.data);
            _context.SaveChanges();
            return await Task.FromResult(request.data);
        }
    }
}
