using MediatR;
using PokemonReviews.Models;

namespace PokemonReviews.Commands.CategoryCommands
{
    public class DeleteCategoryCommand : IRequest<Category>
    {
        public int categoryId { get; set; }
    }
}
