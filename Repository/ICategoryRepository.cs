using Entities;

namespace Repository
{
    public interface ICategoryRepository
    {

        public Task<IEnumerable<Category>> GetCategories(int? maxPrice, int? minPrice, string? name, string? categoryName);
        public Task<Category> addCategory(Category category);
    }
}