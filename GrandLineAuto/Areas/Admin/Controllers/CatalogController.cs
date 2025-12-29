using GrandLineAuto.Data;
using GrandLineAuto.Data.Models;
using GrandLineAuto.Infrastructure.DTO_s;
using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using GrandLineAuto.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GrandLineAuto.Areas.Admin.Controllers
{
    public class CatalogController : AdminBaseController
    {
        private readonly IBaseRepository<Brand> _brandService;
        private readonly IBaseRepository<BrandModelsSeries> _brandModelsSeriesService;

        public CatalogController(IBaseRepository<Brand> brandService, IBaseRepository<BrandModelsSeries> brandModelsSeriesService)
        {
            _brandService = brandService;
            _brandModelsSeriesService = brandModelsSeriesService;
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

        [HttpGet]
        public  IActionResult CreateBrandModelsSeries()
        {
            var model = new BrandModelSeriesVM
            {
                Brands = _brandService
                        .All().OrderBy(b => b.Name).Select(b => new SelectListItem
                        {
                            Value = b.Id.ToString(),
                            Text = b.Name
                        })
            };

            
            return View(model);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBrandModelsSeries(BrandModelSeriesVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = _brandService
                    .All()
                    .OrderBy(b => b.Name)
                    .Select(b => new SelectListItem
                    {
                        Value = b.Id.ToString(),
                        Text = b.Name
                    });

                return View(model);
            }

            var entity = new BrandModelsSeries
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                productionYears = model.productionYears,
                BrandId = model.BrandId
            };

            await _brandModelsSeriesService.AddAsync(entity);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditBrand(Guid brandId) 
        {
           

            var brand = await _brandService.All().Where(b => b.Id == brandId).Select(b => new BrandDTO
            {
                Id = b.Id,
                Name = b.Name,
                ImageUrl = b.ImageUrl
            }).FirstOrDefaultAsync();

            if (brand == null) { return NotFound(); }

            return View("Areas/Admin/Views/Catalog/Edit/EditBrand.cshtml", brand);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBrandConfirmed(BrandDTO model)
        {
            var edited = await _brandService.All().FirstOrDefaultAsync(b => b.Id == model.Id);
           
            
            edited.Name = model.Name;

            edited.ImageUrl = model.ImageUrl;

            await _brandService.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBrand(Guid brandId)
        {
            var brand = await _brandService.All().FirstOrDefaultAsync(b => b.Id == brandId);
            if (brand == null) { return NotFound(); }

            return View("Areas/Admin/Views/Catalog/Delete/DeleteBrand.cshtml", brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteBrand")]
        public async Task<IActionResult> DeleteBrandConfirmed(Guid brandId)
        {
           await _brandService.All().Where(b => b.Id == brandId).ExecuteDeleteAsync();

           return RedirectToAction(nameof(Index));
        }
    }
}
