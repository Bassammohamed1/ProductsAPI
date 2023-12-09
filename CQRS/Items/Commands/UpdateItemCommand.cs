using MediatR;
using TestApi.Models;

namespace TestApi.CQRS.Items.Commands
{
    public record UpdateItemCommand(Item data) : IRequest<Item>;
}
