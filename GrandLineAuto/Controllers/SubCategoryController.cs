using GrandLineAuto.Data;
using GrandLineAuto.Data.Models;
using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GrandLineAuto.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly GrandLineAutoDbContext _dbContext;
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoryController(GrandLineAutoDbContext dbContext, ISubCategoryService subCategoryService)
        {
            _dbContext = dbContext;
            _subCategoryService = subCategoryService;
        }

        public async Task<IActionResult> Index(Guid categoryId, Guid modelId)
        {

            //var subCategories = _dbContext.SubCategories
            //    .Where(sc => sc.CategoryId == categoryId)
            //    .Where(sc => sc.Products.Any(p => p.BrandModelsProducts.Any(bmp => bmp.BrandModelId == modelId)))
            //    .ToList();
            var subCategories = await _subCategoryService.GetSubCategoryBasedOnCategoryIdAndModelId(categoryId, modelId);
            return View(subCategories);
        }
    }
}
