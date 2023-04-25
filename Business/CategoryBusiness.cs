using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository;

namespace Business
{
    public class CategoryBusiness : ICategoryBusiness
    {

        ICategoryRepository _categoryRepository;
        public CategoryBusiness(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> GetCategories(int? maxPrice, int? minPrice, string? name, string? categoryName)
        {
            return await _categoryRepository.GetCategories(maxPrice,  minPrice,  name,  categoryName);
        }
        public async Task<Category> addCategory(Category category)
        {
            return await _categoryRepository.addCategory(category);
        }
    }
}
