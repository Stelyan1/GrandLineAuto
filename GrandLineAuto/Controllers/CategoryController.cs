using GrandLineAuto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Controllers
{
    public class CategoryController : Controller
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public CategoryController(GrandLineAutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(Guid modelId)
        {
            var categories = _dbContext.Categories
                .Where(c => c.subCategories
                             .Any(sc => sc.Products
                                          .Any(p => p.BrandModelsProducts
                                                     .Any(bmp => bmp.BrandModelId == modelId))))
                .ToList();

            ViewBag.ModelId = modelId;

            return View(categories);
        }
    }
}
