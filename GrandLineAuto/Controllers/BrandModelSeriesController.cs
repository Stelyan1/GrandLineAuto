using GrandLineAuto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Controllers
{
    public class BrandModelSeriesController : Controller
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public BrandModelSeriesController(GrandLineAutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(Guid brandId)
        {
            var brandModelSeries = _dbContext.BrandModelsSeries
                .AsNoTracking()
                .Where(bms => bms.BrandId == brandId)
                .OrderBy(bms => bms.Name)
                .ToList();

            return View(brandModelSeries);
        }
    }
}
