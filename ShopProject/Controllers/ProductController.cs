using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Services.ProductService;

namespace ShopProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "Get All Products")]
        public async Task<IActionResult> GetAll()
        {
            var result = _productService.List();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = _productService.Get(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            _productService.Add(product);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = _productService.Get(id);

            _productService.Delete(product);
            
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, Product request)
        {
            var product = _productService.Get(id);

            if(product == null)
            {
                return NotFound("No product with sych id");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            _productService.Update(product);

            return Ok();
        }
    }
}
