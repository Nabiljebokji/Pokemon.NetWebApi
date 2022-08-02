using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonReviews.Data;
using PokemonReviews.Models;

namespace PokemonReviews.Commands.CategoryCommands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            var categoryToDelete = await _context.Categories.Where(c => c.Id == request.categoryId).FirstOrDefaultAsync();
            _context.Categories.Remove(categoryToDelete);
            await _context.SaveChangesAsync();

            return categoryToDelete;
        }
    }
}
