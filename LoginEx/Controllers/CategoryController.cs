using Entities;
using Business;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryBusiness _categoryBusiness;

        public CategoryController(ICategoryBusiness categoryBusiness)
        {
            this._categoryBusiness = categoryBusiness;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get([FromQuery] int? maxPrice, [FromQuery] int? minPrice, [FromQuery] string? name, [FromQuery] string? categoryName)
        {
            IEnumerable<Category> categories = await _categoryBusiness.GetCategories(maxPrice, minPrice, name, categoryName);
            return categories.Count()>0 ? Ok(categories) : NoContent();
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category category)
        {
            Category newCategory = await _categoryBusiness.addCategory(category);
            return newCategory!=null ? Ok(newCategory) : BadRequest();
        }

    }
}
