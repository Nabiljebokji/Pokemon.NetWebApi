
using PokemonReviews.Models;

namespace PokemonReviews.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetCategories();
        public Task<Category> GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        public Task<bool> CategoryExists(int id);
        public Task<bool> CreateCategory(Category category);
        public Task<bool> UpdateCategory(Category category);
        public Task<bool> DeleteCategory(Category category);
        public Task<bool> Save();
    }
}
