using MediatR;
using TestApi.CQRS.Items.Queries;
using TestApi.Models;

namespace TestApi.CQRS.Items.Handler
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdQuery, Item>
    {
        private readonly Context _context;

        public GetItemByIdHandler(Context context)
        {
            _context = context;
        }

        public async Task<Item> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _context.Items.FindAsync(request.id));
        }
    }
}
