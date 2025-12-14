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

        public IActionResult Index(Guid guidId)
        {
            var model = _dbContext.BrandModels
                .AsNoTracking()
                .Where(x => x.BrandModelsSeriesId == guidId)
                .OrderBy(x => x.Name)
                .ToList();

            return View(model);
        }
    }
}
