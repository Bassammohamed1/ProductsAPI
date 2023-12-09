using MediatR;
using TestApi.Models;

namespace TestApi.CQRS.Categories.Queries
{
    public record GetCategoriesQuery : IRequest<List<Category>>;
}
