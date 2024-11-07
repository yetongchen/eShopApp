using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewMicroservice.ApplicaitonCore.Contracts.IServices;
using ReviewMicroservice.ApplicaitonCore.Entities;
using ReviewMicroservice.ApplicaitonCore.Models.Request;

namespace ReviewMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReviewController : ControllerBase
    {
        private readonly IReviewServiceAsync reviewService;

        public CustomerReviewController(IReviewServiceAsync reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var result = await reviewService.GetAllReviewsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CustomerReviewRequestModel review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await reviewService.CreateReviewAsync(review);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview([FromBody] CustomerReviewRequestModel review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await reviewService.UpdateReviewAsync(review);
            return Ok(result);
        }

        [HttpDelete("delete-{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var result = await reviewService.DeleteReviewAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await reviewService.GetReviewByIdAsync(id);
            return review != null ? Ok(review) : NotFound();
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetReviewsByUserId(int userId){
            return Ok(await reviewService.GetReviewsByUserIdAsync(userId));
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetReviewsByProductId(int productId)
        {
            return Ok(await reviewService.GetReviewsByProductIdAsync(productId));
        }

        [HttpGet("year/{year}")]
        public async Task<IActionResult> GetReviewsByYear(int year)
        {
            return Ok(await reviewService.GetReviewsByYearAsync(year));
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApproveReview(int id)
        {
            var result = await reviewService.ApproveReviewAsync(id);
            return Ok(result);
        }

        [HttpPut("reject/{id}")]
        public async Task<IActionResult> RejectReview(int id)
        {
            var result = await reviewService.RejectReviewAsync(id);
            return Ok(result);
        }
    }
}
