using MediatR;
using TestApi.DTOS;
using TestApi.Models;

namespace TestApi.CQRS.Items.Commands
{
    public record InsertItemCommand(Itemdto data) : IRequest<Item>;
}
