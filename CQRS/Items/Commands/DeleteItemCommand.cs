using MediatR;
using TestApi.Models;

namespace TestApi.CQRS.Items.Commands
{
    public record DeleteItemCommand(Item data) : IRequest<Item>;
}
