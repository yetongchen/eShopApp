using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionMicroservice.ApplicationCore.Contracts.IServices;
using PromotionMicroservice.ApplicationCore.Entities;
using PromotionMicroservice.ApplicationCore.Models.Request;

namespace PromotionMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionServiceAsync promotionServiceAsync;

        public PromotionController(IPromotionServiceAsync promotionServiceAsync)
        {
            this.promotionServiceAsync = promotionServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPromotions()
        {
            return Ok(await promotionServiceAsync.GetAllPromotionsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion([FromBody] PromotionRequestModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await promotionServiceAsync.CreatePromotionAsync(requestModel);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePromotion([FromBody] PromotionRequestModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await promotionServiceAsync.UpdatePromotionAsync(requestModel);
            return result > 0 ? Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromotionById(int id)
        {
            var result = await promotionServiceAsync.GetPromotionByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("delete-{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            var result = await promotionServiceAsync.DeletePromotionAsync(id);
            return Ok(result);
        }

        [HttpGet("promotionByProductName")]
        public async Task<IActionResult> GetPromotionsByProductName([FromQuery] string productName)
        {
            return Ok(await promotionServiceAsync.GetPromotionsByProductCategoryNameAsync(productName));
        }

        [HttpGet("activePromotions")]
        public async Task<IActionResult> GetActivePromotions()
        {
            return Ok(await promotionServiceAsync.GetActivePromotionsAsync());
        }
    }
}
