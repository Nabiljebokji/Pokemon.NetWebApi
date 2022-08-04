using MediatR;
using PokemonReviews.Dto;
using PokemonReviews.Models;

namespace PokemonReviews.Queries.CategoryQuery
{
    public class GetPokemonCategoryIDQuery : IRequest<List<Pokemon>>
    {
        public int categoryId { get; set; }
    }
}
