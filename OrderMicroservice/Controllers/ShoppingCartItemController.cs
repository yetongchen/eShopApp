using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.IServices;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartItemServiceAsync shoppingCartItemService;
        public ShoppingCartItemController(IShoppingCartItemServiceAsync shoppingCartItemService)
        {
            this.shoppingCartItemService = shoppingCartItemService;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingCartItemById(int id)
        {
            var result = await shoppingCartItemService.DeleteShoppingCartItemById(id);
            return Ok(result);
        }
    }
}
