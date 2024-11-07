using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.IServices;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VariationValueController : ControllerBase
    {
        private readonly IVariationValueServiceAsync _variationValueService;

        public VariationValueController(IVariationValueServiceAsync variationValueService)
        {
            _variationValueService = variationValueService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(VariationValueRequestModel model)
        {
            var result = await _variationValueService.SaveVariationValueAsync(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetVariationId(int variationId)
        {
            var result = await _variationValueService.GetVariationValuesAsync(variationId);
            return Ok(result);
        }
    }
}
