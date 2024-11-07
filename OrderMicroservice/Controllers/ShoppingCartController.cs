using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.IServices;
using OrderMicroservice.ApplicationCore.Models.Request;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartServiceAsync shoppingCartService;
        public ShoppingCartController(IShoppingCartServiceAsync shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingCartByCustomerId(int customerId)
        {
            var result = await shoppingCartService.GetShoppingCartsByCustomerId(customerId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveShoppingCart([FromBody]ShoppingCartRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await shoppingCartService.SaveShoppingCart(model);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingCart(int id)
        {
            var result = await shoppingCartService.DeleteShoppingCart(id);
            return Ok(result);
        }
    }
}
