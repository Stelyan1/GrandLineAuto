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
       
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoryController(GrandLineAutoDbContext dbContext, ISubCategoryService subCategoryService)
        {
           
            _subCategoryService = subCategoryService;
        }

        public async Task<IActionResult> Index(Guid categoryId, Guid modelId)
        {
            var subCategories = await _subCategoryService.GetSubCategoryBasedOnCategoryIdAndModelId(categoryId, modelId);
            return View(subCategories);
        }
    }
}
