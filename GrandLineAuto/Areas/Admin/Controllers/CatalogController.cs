using GrandLineAuto.Areas.Admin.Views.Models;
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
using Microsoft.VisualStudio.TextTemplating;
using Org.BouncyCastle.Crypto;
using System.Threading.Tasks;
using static GrandLineAuto.Common.EntityValidation;
using Brand = GrandLineAuto.Data.Models.Brand;
using BrandModels = GrandLineAuto.Data.Models.BrandModels;
using BrandModelsSeries = GrandLineAuto.Data.Models.BrandModelsSeries;

namespace GrandLineAuto.Areas.Admin.Controllers
{
    public class CatalogController : AdminBaseController
    {
        private readonly IBaseRepository<Brand> _brandService;
        private readonly IBaseRepository<BrandModelsSeries> _brandModelsSeriesService;
        private readonly IBaseRepository<BrandModels> _brandModelsService;

        public CatalogController(IBaseRepository<Brand> brandService, IBaseRepository<BrandModelsSeries> brandModelsSeriesService, IBaseRepository<BrandModels> brandModelsService)
        {
            _brandService = brandService;
            _brandModelsSeriesService = brandModelsSeriesService;
            _brandModelsService = brandModelsService;
        }

        public IActionResult Index() => View();

        // Меню-то от Dashboard сочи към тези:
        public IActionResult Products() => View();

        [HttpGet]
        public async Task<IActionResult> ManageBrands()
        {
            var brands = await _brandService.GetAllAsync();

            return View("Areas/Admin/Views/Catalog/Manage/ManageBrands.cshtml", brands);
        } 

        [HttpGet]
        public async Task<IActionResult> ManageBrandModelSeries()
        {
            var brandModelSeries = await _brandModelsSeriesService.GetAllAsync();

            return View("Areas/Admin/Views/Catalog/Manage/ManageBrandModelSeries.cshtml", brandModelSeries);
        }

        [HttpGet]
        public async Task<IActionResult> ManageBrandModels()
        {
            var brandModels = await _brandModelsService.GetAllAsync();

            return View("Areas/Admin/Views/Catalog/Manage/ManageBrandModels.cshtml", brandModels);
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

        [HttpGet]
        public IActionResult CreateBrandModels()
        {
            var model = new BrandModelsVM
            {
                BrandModelSeries = _brandModelsSeriesService
                                   .All().OrderBy(bms => bms.Name).Select(bms => new SelectListItem
                                   {
                                       Value = bms.Id.ToString(),
                                       Text = bms.Name
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBrandModels(BrandModelsVM model)
        {
            if (!ModelState.IsValid)
            {
                model = new BrandModelsVM
                {
                    BrandModelSeries = _brandModelsSeriesService.All().OrderBy(bms => bms.Name).Select(bms => new SelectListItem
                    {
                        Value = bms.Id.ToString(),
                        Text = bms.Name
                    })
                };

                return View(model);
            }

            var entity = new BrandModels
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                yearProduced = model.yearProduced,
                typeCoupe = model.typeCoupe,
                fuelType = model.fuelType,
                Engine = model.Engine,
                BrandModelsSeriesId = model.BrandModelsSeriesId
            };

            await _brandModelsService.AddAsync(entity);
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

        [HttpGet]
        public async Task<IActionResult> EditBrandModelSeries(Guid brandModelSeriesId)
        {
            var brandModelSeries = await _brandModelsSeriesService.All().Where(bms => bms.Id == brandModelSeriesId).Select(bms => new BrandModelSeriesVM
            {
                Id = bms.Id,
                Name = bms.Name,
                ImageUrl = bms.ImageUrl,
                productionYears = bms.productionYears,
                BrandId = bms.BrandId
            }).FirstOrDefaultAsync();

            if (brandModelSeries == null) { return NotFound(); }

            return View("Areas/Admin/Views/Catalog/Edit/EditBrandModelSeries.cshtml", brandModelSeries);
        }

        [HttpGet]
        public async Task<IActionResult> EditBrandModels(Guid brandModelsId)
        {
            var brandModels = await _brandModelsService.All().Where(bm => bm.Id == brandModelsId).Select(bm => new BrandModelsVM
            {
                Id = bm.Id,
                Name = bm.Name,
                ImageUrl = bm.ImageUrl,
                yearProduced = bm.yearProduced,
                typeCoupe = bm.typeCoupe,
                fuelType = bm.fuelType,
                Engine = bm.Engine
            }).FirstOrDefaultAsync();

            if (brandModels == null) { return NotFound(); }

            return View("Areas/Admin/Views/Catalog/Edit/EditBrandModels.cshtml", brandModels);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> EditBrandModelSeriesConfirmed(BrandModelSeriesVM model)
        {
            var edited = await _brandModelsSeriesService.All().FirstOrDefaultAsync(bms => bms.Id == model.Id);

            edited.Name = model.Name;

            edited.ImageUrl = model.ImageUrl;

            edited.productionYears = model.productionYears;

            await _brandService.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBrandModelsConfirmed(BrandModelsVM model) 
        {
            var edited = await _brandModelsService.All().FirstOrDefaultAsync(bm => bm.Id == model.Id);

            edited.Name = model.Name;

            edited.ImageUrl = model.ImageUrl;

            edited.yearProduced = model.yearProduced;

            edited.typeCoupe = model.typeCoupe;

            edited.fuelType = model.fuelType;

            edited.Engine = model.Engine;

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

        [HttpGet]
        public async Task<IActionResult> DeleteBrandModelSeries(Guid brandModelSeriesId)
        {
            var brandModelSeries = await _brandModelsSeriesService.All().FirstOrDefaultAsync(bms => bms.Id == brandModelSeriesId);

            if (brandModelSeries == null) { return NotFound(); }

            return View("Areas/Admin/Views/Catalog/Delete/DeleteBrandModelSeries.cshtml", brandModelSeries);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBrandModels(Guid brandModelsId)
        {
            var brandModels = await _brandModelsService.All().FirstOrDefaultAsync(bm => bm.Id == brandModelsId);

            if (brandModels == null) { return NotFound(); }

            return View("Areas/Admin/Views/Catalog/Delete/DeleteBrandModels.cshtml", brandModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteBrand")]
        public async Task<IActionResult> DeleteBrandConfirmed(Guid brandId)
        {
           await _brandService.All().Where(b => b.Id == brandId).ExecuteDeleteAsync();

           return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteBrandModelSeries")]
        public async Task <IActionResult> DeleteBrandModelSeriesConfirmed(Guid brandModelSeriesId)
        {
            await _brandModelsSeriesService.All().Where(bms => bms.Id == brandModelSeriesId).ExecuteDeleteAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteBrandModels")]
        public async Task<IActionResult> DeleteBrandModelsConfirmed(Guid brandModelsId)
        {
            await _brandModelsService.All().Where(bm => bm.Id == brandModelsId).ExecuteDeleteAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
