using AutoMapper;
using MediatR;
using PokemonReviews.Data;
using PokemonReviews.Dto;
using PokemonReviews.Models;
using PokemonReviews.Repository;

namespace PokemonReviews.Commands.CategoryCommands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly CategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
           
        }
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryMap = _mapper.Map<Category>(request.categoryDto);
            
            return request.categoryDto;
        }
    }
}
