using AutoMapper;
using MediatR;
using PokemonReviews.Data;
using PokemonReviews.Dto;
using PokemonReviews.Models;

namespace PokemonReviews.Commands.CategoryCommands
{
    public class UpdateCategoryIdCommandHandler : IRequestHandler<UpdateCategoryIdCommand, CategoryDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryIdCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(UpdateCategoryIdCommand request, CancellationToken cancellationToken)
        {
            var categoryMap = _mapper.Map<Category>(request.updatedCategory);

            _context.Update(categoryMap);
            await _context.SaveChangesAsync();

            return request.updatedCategory;
        }
    }
}
