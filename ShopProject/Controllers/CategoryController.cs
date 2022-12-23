using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Services.CategoryService;

namespace ShopProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = _categoryService.Get(id);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            _categoryService.Add(category);

            return Ok();
        }
        [HttpGet("Get by category")]

        public async Task<IActionResult> GetProducts(Guid id)
        {
            var result = _categoryService.GetProductsByCategory(id);

            return Ok(result);
        }

        [HttpGet("Get List")]
        public async Task<IActionResult> GetAll()
        {
            var result = _categoryService.List();

            return Ok(result);
        }
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = _categoryService.Get(id);

            _categoryService.Delete(category);

            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, Category request)
        {
            var category = _categoryService.Get(id);

            if (category is null)
            {
                return BadRequest();
            }

            category.Name = request.Name;

            _categoryService.Update(category);

            return Ok();
        }
    }
}
