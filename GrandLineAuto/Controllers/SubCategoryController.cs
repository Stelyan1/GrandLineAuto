using GrandLineAuto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public SubCategoryController(GrandLineAutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(Guid modelId)
        {
            var model = _dbContext.SubCategories
                .AsNoTracking()
                .Where(m => m.CategoryId == modelId)
              
                .ToList();

            return View(model);
        }
    }
}
