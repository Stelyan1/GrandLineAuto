using GrandLineAuto.Data;
using GrandLineAuto.Infrastructure.Services;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GrandLineAuto.Controllers
{
    public class BrandModelsController : Controller
    {
       

        private readonly IBrandModelsService _brandModelsService;
        public BrandModelsController(IBrandModelsService brandModelsService)
        {
           
            _brandModelsService = brandModelsService;
        }

        public async Task<IActionResult> Index(Guid brandModelSeriesId)
        {
            var bm = await _brandModelsService.GetBrandModelsBySeriesId(brandModelSeriesId);

            

            return View(bm);
        }
    }
}
