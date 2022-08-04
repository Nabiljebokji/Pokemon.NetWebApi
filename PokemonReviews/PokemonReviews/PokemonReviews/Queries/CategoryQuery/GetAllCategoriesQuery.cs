using MediatR;
using PokemonReviews.Dto;

namespace PokemonReviews.Queries.CategoryQuery
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
    {

    }
}
