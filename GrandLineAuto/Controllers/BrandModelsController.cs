using GrandLineAuto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Controllers
{
    public class BrandModelsController : Controller
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public BrandModelsController(GrandLineAutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(Guid brandModelSeriesId)
        {
            var brandModels = _dbContext.BrandModels
                .AsNoTracking()
                .Where(bm => bm.BrandModelsSeriesId == brandModelSeriesId)
                .OrderBy(bm => bm.Name)
                .ToList();

            return View(brandModels);
        }
    }
}
