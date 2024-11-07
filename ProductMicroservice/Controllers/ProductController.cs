using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.IServices;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync _productService;

        public ProductController(IProductServiceAsync productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] int? categoryId = null)
        {
            var result = await _productService.GetPaginatedProductsAsync(pageNumber, pageSize, categoryId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductRequestModel model)
        {
            var result = await _productService.SaveProductAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductRequestModel model)
        {
            var result = await _productService.UpdateProductAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> InActive(int id)
        {
            var result = await _productService.InactivateProductAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByCategoryId(int categoryId)
        {
            var result = await _productService.GetProductsByCategoryIdAsync(categoryId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var result = await _productService.GetProductByNameAsync(name);
            return result != null ? Ok(result) : NotFound();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            return result > 0 ? Ok() : NotFound();
        }
    }
}
