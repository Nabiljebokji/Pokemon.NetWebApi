using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonReviews.Dto;
using PokemonReviews.Interfaces;
using PokemonReviews.Models;

namespace PokemonReviews.Queries.CategoryQuery
{
    public class GetPokemonCategoryIDQueryHandler : IRequestHandler<GetPokemonCategoryIDQuery, List<Pokemon>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetPokemonCategoryIDQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<Pokemon>> Handle(GetPokemonCategoryIDQuery request, CancellationToken cancellationToken)
        {
            var thisPokCat  = await _categoryRepository.GetPokemonByCategory(request.categoryId);
            var Map = _mapper.Map<List<Pokemon>>(thisPokCat);
            return Map;
        }
    }
}
