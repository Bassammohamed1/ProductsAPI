using MediatR;
using TestApi.DTOS;
using TestApi.Models;

namespace TestApi.CQRS.Categories.Commands
{
    public record InsertCategoryCommand(Categorydto data) : IRequest<Category>;
}
