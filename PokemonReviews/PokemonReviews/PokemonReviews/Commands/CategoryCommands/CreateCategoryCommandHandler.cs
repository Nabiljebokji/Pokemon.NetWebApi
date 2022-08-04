using AutoMapper;
using MediatR;
using PokemonReviews.Dto;
using PokemonReviews.Interfaces;
using PokemonReviews.Models;

namespace PokemonReviews.Commands.CategoryCommands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler( IMapper mapper, ICategoryRepository _categoryRepository)
        {
           
            _mapper = mapper;
            this._categoryRepository = _categoryRepository;
        }
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var categoryMap = _mapper.Map<Category>(request.categoryDto);
            await _categoryRepository.CreateCategory(categoryMap);
            return request.categoryDto;
        }
    }
}
