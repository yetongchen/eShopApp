using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.IServices;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationServiceAsync _productVariationService;

        public ProductVariationController(IProductVariationServiceAsync productVariationService)
        {
            _productVariationService = productVariationService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductVariationRequestModel model)
        {
            var result = await _productVariationService.SaveProductVariationAsync(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductVariation(int productId)
        {
            var result = await _productVariationService.GetProductVariationsAsync(productId);
            return Ok(result);
        }
    }
}
