using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        Store214089435Context _store214089435;

        public CategoryRepository(Store214089435Context store214104465)
        {
            this._store214089435 = store214104465;
        }
        public async Task<IEnumerable<Category>> GetCategories(int? maxPrice, int? minPrice, string? name, string? categoryName)
        {
            var categories = await _store214089435.Categories.Where((category) => { })
            return categories;
        }
        public async Task<Category> addCategory(Category category)
        {
            await _store214089435.Categories.AddAsync(category);
            await _store214089435.SaveChangesAsync();
            return category;
        }
    }
}
