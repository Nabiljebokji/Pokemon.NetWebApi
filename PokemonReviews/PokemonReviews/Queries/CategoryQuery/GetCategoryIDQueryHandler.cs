using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonReviews.Data;
using PokemonReviews.Dto;

namespace PokemonReviews.Queries.CategoryQuery
{
    public class GetCategoryIDQueryHandler : IRequestHandler<GetCategoryIDQuery, int>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GetCategoryIDQueryHandler(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<int> Handle(GetCategoryIDQuery request, CancellationToken cancellationToken)
        {
            var thisId = await _context.Categories.Where(c => c.Id == request.categoryId).FirstOrDefaultAsync();
            var categories = _mapper.Map<CategoryDto>(thisId);
            return request.categoryId;
        }
    }
}
