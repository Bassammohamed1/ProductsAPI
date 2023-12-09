using MediatR;
using TestApi.Models;

namespace TestApi.CQRS.Categories.Commands
{
    public record DeleteCategoryCommand(Category data) : IRequest<Category>;
}
