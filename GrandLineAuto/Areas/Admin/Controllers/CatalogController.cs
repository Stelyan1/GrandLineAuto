using GrandLineAuto.Data;
using GrandLineAuto.Data.Models;
using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GrandLineAuto.Areas.Admin.Controllers
{
    public class CatalogController : AdminBaseController
    {
        private readonly IBaseRepository<Brand> _brandService;

        public CatalogController(IBaseRepository<Brand> brandService)
        {
            _brandService = brandService;
        }

        public IActionResult Index() => View();

        // Меню-то от Dashboard сочи към тези:
        public IActionResult Products() => View();
        public async Task<IActionResult> ManageBrands()
        {
            var brands = await _brandService.GetAllAsync();

            return View("Areas/Admin/Views/Catalog/Manage/ManageBrands.cshtml", brands);
        } 
        public IActionResult Categories() => View();

        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        public IActionResult CreateProduct() => View();
        public IActionResult CreateCategory() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBrand(Brand model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            } 

            model.Id = Guid.NewGuid();

            await _brandService.AddAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
