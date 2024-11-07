using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.IServices;
using OrderMicroservice.ApplicationCore.Models.Request;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync customerService;

        public CustomerController(ICustomerServiceAsync customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerAddressByUserId(int userId)
        {
            var result = await customerService.GetCustomerAddressesByUserId(userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCustomerAddress([FromBody] CustomerAddressRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await customerService.SaveCustomerAddress(request);
            return Ok(result);            
        }
    }
}
