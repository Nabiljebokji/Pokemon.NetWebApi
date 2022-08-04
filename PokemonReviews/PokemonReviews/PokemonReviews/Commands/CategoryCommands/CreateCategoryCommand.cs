using MediatR;
using PokemonReviews.Dto;

namespace PokemonReviews.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public CategoryDto categoryDto { get; set; }
    }
}
