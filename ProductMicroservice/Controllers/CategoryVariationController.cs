using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.IServices;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryVariationController : ControllerBase
    {
        private readonly ICategoryVariationServiceAsync _categoryVariationService;

        public CategoryVariationController(ICategoryVariationServiceAsync categoryVariationService)
        {
            _categoryVariationService = categoryVariationService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryVariationRequestModel model)
        {
            var result = await _categoryVariationService.SaveCategoryVariationAsync(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryVariationService.GetAllCategoryVariationsAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryVariationById(int id)
        {
            var result = await _categoryVariationService.GetCategoryVariationByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryVariationByCategoryId(int categoryId)
        {
            var result = await _categoryVariationService.GetCategoryVariationByCategoryIdAsync(categoryId);
            return Ok(result);
        }        
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryVariationService.DeleteCategoryVariationAsync(id);
            return result > 0 ? Ok() : NotFound();
        }
    }
}
