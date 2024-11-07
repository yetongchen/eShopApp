using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.IServices;
using OrderMicroservice.ApplicationCore.Models.Request;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync orderService;

        public OrderController(IOrderServiceAsync orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder([FromBody] OrderRequestModel orderRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await orderService.InsertOrder(orderRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> CheckOrderHistory(int customerId)
        {
            var orders = await orderService.GetOrdersByCustomerId(customerId);
            return Ok(orders);
        }

        [HttpGet]
        public async Task<IActionResult> CheckOrderStatus(int id)
        {
            var result = await orderService.GetOrderStatus(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var result = await orderService.CancelOrder(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> OrderCompleted(int id)
        {
            var result = await orderService.CompleteOrder(id);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody]OrderRequestModel orderRequest, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await orderService.UpdateOrder(orderRequest, id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
