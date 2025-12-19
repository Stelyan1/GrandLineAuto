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

        public IActionResult Index(Guid categoryId, Guid modelId)
        {

            var subCategories = _dbContext.SubCategories
                .Where(sc => sc.CategoryId == categoryId)
                .Where(sc => sc.Products.Any(p => p.BrandModelsProducts.Any(bmp => bmp.BrandModelId == modelId)))
                .ToList();

            return View(subCategories);
        }
    }
}
