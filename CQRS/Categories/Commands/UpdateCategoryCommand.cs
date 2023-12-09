using MediatR;
using TestApi.Models;

namespace TestApi.CQRS.Categories.Commands
{
    public record UpdateCategoryCommand(Category data) : IRequest<Category>;
}
