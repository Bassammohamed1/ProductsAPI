using MediatR;
using TestApi.Models;

namespace TestApi.CQRS.Categories.Queries
{
    public record GetCategoryByIdQuery(int id) : IRequest<Category>;
}
