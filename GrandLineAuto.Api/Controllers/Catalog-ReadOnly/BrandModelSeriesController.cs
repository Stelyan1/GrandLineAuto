using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrandLineAuto.Api.Controllers
{
    
    [ApiController]
    [Route("api/brands/{brandId:guid}/series")]
    public class BrandModelSeriesController : ControllerBase
    {
        private readonly IBrandModelsSeriesService _brandModelsSeriesService;

        public BrandModelSeriesController(IBrandModelsSeriesService brandModelsSeriesService)
        {
            _brandModelsSeriesService = brandModelsSeriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByBrandId([FromRoute] Guid brandId)
        {
            var brandModelSeries = await _brandModelsSeriesService.GetEntityByBrandId(brandId);

            return Ok(brandModelSeries);
        }
    }
}
