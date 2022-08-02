using MediatR;

namespace PokemonReviews.Queries.CategoryQuery
{
    public class GetCategoryIDQuery : IRequest<int>
    {
        public int categoryId { get; set; }
    }
}
