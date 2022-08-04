using AutoMapper;
using MediatR;
using PokemonReviews.Data;
using PokemonReviews.Dto;
using PokemonReviews.Interfaces;

namespace PokemonReviews.Queries.CategoryQuery
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesQueryHandler( IMapper mapper, ICategoryRepository _categoryRepository)
        {
            _mapper = mapper;
            this._categoryRepository = _categoryRepository;
        }
        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var Category =  await _categoryRepository.GetCategories();
            var categories = _mapper.Map<List<CategoryDto>>(Category);

            return categories;
        }
    }
}
