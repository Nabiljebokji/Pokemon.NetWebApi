using AutoMapper;
using MediatR;
using PokemonReviews.Data;
using PokemonReviews.Dto;

namespace PokemonReviews.Queries.CategoryQuery
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {

            var categories = _mapper.Map<List<CategoryDto>>(_context.Categories.ToList());

            return categories;
        }
    }
}
