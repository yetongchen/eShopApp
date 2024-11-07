using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingMicroservice.ApplicationCore.Contracts.IServices;
using ShippingMicroservice.ApplicationCore.Models.Request;
using ShippingMicroservice.ApplicationCore.Models.Response;

namespace ShippingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperServiceAsync shipperServiceAsync;

        public ShipperController(IShipperServiceAsync shipperServiceAsync)
        {
            this.shipperServiceAsync = shipperServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await shipperServiceAsync.GetAllShippersAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShipperRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await shipperServiceAsync.AddShipperAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ShipperRequestModel request, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await shipperServiceAsync.UpdateShipperAsync(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await shipperServiceAsync.GetShipperByIdAsync(id);
            if (result == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(result);
        }

        [HttpDelete("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await shipperServiceAsync.DeleteShipperAsync(id);
            return Ok(result);
        }

        [HttpGet("region/{region}")]
        public async Task<IActionResult> GetByRegion(string region)
        {
            var result = await shipperServiceAsync.GetShipperByRegionAsync(region);
            return Ok(result);
        }
    }
}
