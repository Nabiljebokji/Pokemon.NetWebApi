using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviews.Data;
using PokemonReviews.Interfaces;
using PokemonReviews.Models;

namespace PokemonReviews.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CategoryExists(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }


        public async Task<bool> CreateCategory(Models.Category category)
        {
            await _context.AddAsync(category);

            return await Save();
        }

        public async Task<bool> DeleteCategory(Category category)
        {
            _context.Remove(category);
            return await Save();
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }
        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            _context.Update(category);
            return await Save();
        }
    }
}