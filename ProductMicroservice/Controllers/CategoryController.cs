using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.IServices;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServiceAsync _categoryService;

        public CategoryController(ICategoryServiceAsync categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveCategory(CategoryRequestModel model)
        {
            var result = await _categoryService.SaveCategoryAsync(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _categoryService.GetAllCategoriesAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _categoryService.GetCategoryByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            return result > 0 ? Ok() : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryByParentCategoryId(int parentCategoryId)
        {
            var result = await _categoryService.GetCategoryByParentCategoryIdAsync(parentCategoryId);
            return Ok(result);
        }
    }
}
