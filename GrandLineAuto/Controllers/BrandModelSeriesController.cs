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
            

            var model = _dbContext.BrandModelsSeries
                .AsNoTracking()
                .Where(x => x.BrandId == brandId)
                .OrderBy(x => x.Name)
                .ToList();

            return View(model);
        }
    }
}
