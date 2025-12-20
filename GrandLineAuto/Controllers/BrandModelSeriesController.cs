using GrandLineAuto.Data;
using GrandLineAuto.Data.Models;
using GrandLineAuto.Infrastructure.DTO_s;
using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GrandLineAuto.Controllers
{
    public class BrandModelSeriesController : Controller
    {
       
        private readonly IBrandModelsSeriesService _brandModelsSeries;

        public BrandModelSeriesController(IBrandModelsSeriesService brandModelsSeries)
        {
           
            _brandModelsSeries = brandModelsSeries;
        }
        
        public async Task<IActionResult> Index(Guid brandId)
        {

            var bms = await _brandModelsSeries.GetEntityByBrandId(brandId);
            return View(bms);
        }
    }
}
