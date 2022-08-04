using MediatR;
using PokemonReviews.Dto;

namespace PokemonReviews.Commands.CategoryCommands
{
    public class UpdateCategoryIdCommand : IRequest<CategoryDto>
    {
        public int categoryID { get; set; }
        public CategoryDto updatedCategory { get; set; }
    }
}
