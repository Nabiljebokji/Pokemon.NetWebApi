using MediatR;
using PokemonReviews.Dto;

namespace PokemonReviews.Queries.CategoryQuery
{
    public class GetCategoryIDQuery : IRequest<CategoryDto>
    {
        public int categoryId { get; set; }
    }
}
