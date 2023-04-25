using Entities;

namespace Business
{
    public interface ICategoryBusiness
    {
        Task<Category> addCategory(Category category);
        Task<IEnumerable<Category>> GetCategories(int? maxPrice, int? minPrice,string? name, string? categoryName);
    }
}