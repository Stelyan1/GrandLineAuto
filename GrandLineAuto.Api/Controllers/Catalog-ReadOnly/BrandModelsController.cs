using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrandLineAuto.Api.Controllers
{
   
    [ApiController]
    [Route("api/series/{seriesId:guid}/models")]
    public class BrandModelsController : ControllerBase
    {
        private readonly IBrandModelsService _brandModelsService;

        public BrandModelsController(IBrandModelsService brandModelsService)
        {
            _brandModelsService = brandModelsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByBrandModelsSeriesId([FromRoute] Guid seriesId)
        {
            var brandModels = await _brandModelsService.GetBrandModelsBySeriesId(seriesId);

            return Ok(brandModels);
        }
    }
}
