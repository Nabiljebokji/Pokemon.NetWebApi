using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonReviews.Data;
using PokemonReviews.Dto;
using PokemonReviews.Interfaces;

namespace PokemonReviews.Queries.CategoryQuery
{
    public class GetCategoryIDQueryHandler : IRequestHandler<GetCategoryIDQuery, CategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryIDQueryHandler(IMapper mapper,ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryDto> Handle(GetCategoryIDQuery request, CancellationToken cancellationToken)
        {
            var thisCat = await _categoryRepository.GetCategory(request.categoryId);
           
            var categories = _mapper.Map<CategoryDto>(thisCat);
            return categories;
        }
    }
}
