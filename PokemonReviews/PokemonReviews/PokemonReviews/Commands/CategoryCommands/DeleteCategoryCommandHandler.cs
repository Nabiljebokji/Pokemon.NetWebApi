using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonReviews.Data;
using PokemonReviews.Interfaces;
using PokemonReviews.Models;

namespace PokemonReviews.Commands.CategoryCommands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {

        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var thisCat = await _categoryRepository.GetCategory(request.categoryId);
            _categoryRepository.DeleteCategory(thisCat);

            return thisCat;

        }
    }
}
