using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.IServices;
using OrderMicroservice.ApplicationCore.Models.Request;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServiceAsync paymentService;

        public PaymentController(IPaymentServiceAsync paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentByCustomerId(int customerId)
        {
            var payments = await paymentService.GetPaymentsByCustomerIdAsync(customerId);
            return Ok(payments);
        }

        [HttpPost]
        public async Task<IActionResult> SavePayment([FromBody] PaymentRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await paymentService.SavePaymentAsync(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var result = await paymentService.DeletePaymentAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePayment([FromBody] PaymentRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await paymentService.UpdatePaymentAsync(request);
            return Ok(result);
        }
    }
}
