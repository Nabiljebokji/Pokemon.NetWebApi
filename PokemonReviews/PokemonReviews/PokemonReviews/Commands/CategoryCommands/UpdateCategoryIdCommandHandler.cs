using AutoMapper;
using MediatR;
using PokemonReviews.Data;
using PokemonReviews.Dto;
using PokemonReviews.Interfaces;
using PokemonReviews.Models;

namespace PokemonReviews.Commands.CategoryCommands
{
    public class UpdateCategoryIdCommandHandler : IRequestHandler<UpdateCategoryIdCommand, CategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryIdCommandHandler( IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryDto> Handle(UpdateCategoryIdCommand request, CancellationToken cancellationToken)
        {
            var categoryMap = _mapper.Map<Category>(request.updatedCategory);

           await _categoryRepository.UpdateCategory(categoryMap);

            return request.updatedCategory;
        }
    }
}
