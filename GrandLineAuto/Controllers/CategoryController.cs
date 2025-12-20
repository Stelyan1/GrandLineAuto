using GrandLineAuto.Data;
using GrandLineAuto.Infrastructure.Services;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GrandLineAuto.Controllers
{
    public class CategoryController : Controller
    {
        private readonly GrandLineAutoDbContext _dbContext;
        private readonly ICategoryService _categoryService;

        public CategoryController(GrandLineAutoDbContext dbContext, ICategoryService categoryService)
        {
            _dbContext = dbContext;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(Guid modelId)
        {
            
            var categories = await _categoryService.GetCategoriesForGivenModel(modelId);
            ViewBag.ModelId = modelId;

            return View(categories);
        }
    }
}
