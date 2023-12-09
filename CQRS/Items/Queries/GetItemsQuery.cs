using MediatR;
using TestApi.Models;

namespace TestApi.CQRS.Items.Queries
{
    public record GetItemsQuery : IRequest<List<Item>>;
}
