using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonReviews.Data;
using PokemonReviews.Dto;

namespace PokemonReviews.Queries.CategoryQuery
{
    public class GetPokemonCategoryIDQueryHandler : IRequestHandler<GetPokemonCategoryIDQuery, PokemonDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetPokemonCategoryIDQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PokemonDto> Handle(GetPokemonCategoryIDQuery request, CancellationToken cancellationToken)
        {
            var thisId = await _context.Pokemon.Where(p => p.Id == request.categoryId).FirstOrDefaultAsync();
            var pokemons = _mapper.Map<PokemonDto>(thisId);
            return pokemons;
        }
    }
}
