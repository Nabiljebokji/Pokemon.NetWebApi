using MediatR;
using PokemonReviews.Dto;

namespace PokemonReviews.Queries.CategoryQuery
{
    public class GetPokemonCategoryIDQuery : IRequest<PokemonDto>
    {
        public int categoryId { get; set; }
    }
}
