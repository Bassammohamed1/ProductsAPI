using MediatR;
using TestApi.Models;

namespace TestApi.CQRS.Items.Queries
{
    public record GetItemByIdQuery(int id): IRequest<Item>;
}
