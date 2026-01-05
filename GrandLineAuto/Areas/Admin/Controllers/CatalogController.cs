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
using Category = GrandLineAuto.Data.Models.Category;
using Product = GrandLineAuto.Data.Models.Product;
using ProductManufacturer = GrandLineAuto.Data.Models.ProductManufacturer;
using SubCategory = GrandLineAuto.Data.Models.SubCategory;

namespace GrandLineAuto.Areas.Admin.Controllers
{
    public class CatalogController : AdminBaseController
    {
        private readonly IBaseRepository<Brand> _brandService;
        private readonly IBaseRepository<BrandModelsSeries> _brandModelsSeriesService;
        private readonly IBaseRepository<BrandModels> _brandModelsService;
        private readonly IBaseRepository<Category> _categoryService;
        private readonly IBaseRepository<SubCategory> _subCategoryService;
        private readonly IBaseRepository<ProductManufacturer> _productManufacturerService;
        private readonly IBaseRepository<Product> _productService;
        private readonly IBaseRepository<BrandModelProductJoinTable> _brandModelProductJoinTableService;

        public CatalogController(IBaseRepository<Brand> brandService, IBaseRepository<BrandModelsSeries> brandModelsSeriesService, IBaseRepository<BrandModels> brandModelsService, 
            IBaseRepository<Category> categoryService, IBaseRepository<SubCategory> subCategoryService,
            IBaseRepository<ProductManufacturer> productManufacturerService, IBaseRepository<Product> productService, IBaseRepository<BrandModelProductJoinTable> brandModelProductJoinTableService)
        {
            _brandService = brandService;
            _brandModelsSeriesService = brandModelsSeriesService;
            _brandModelsService = brandModelsService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _productManufacturerService = productManufacturerService;
            _productService = productService;
            _brandModelProductJoinTableService = brandModelProductJoinTableService;
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

        [HttpGet]
        public async Task<IActionResult> ManageCategories()
        {
            var categories = await _categoryService.GetAllAsync();

            return View("Areas/Admin/Views/Catalog/Manage/ManageCategories.cshtml", categories);
        }

        [HttpGet]
        public async Task<IActionResult> ManageSubCategories()
        {
            var subCategories = await _subCategoryService.GetAllAsync();

            return View("Areas/Admin/Views/Catalog/Manage/ManageSubCategories.cshtml", subCategories);
        }

        [HttpGet]
        public async Task<IActionResult> ManageProducts()
        {
            var products = await _productService.GetAllAsync();

            return View("Areas/Admin/Views/Catalog/Manage/ManageProducts.cshtml", products);
        }

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

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateSubCategory()
        {
            var categories = new SubCategoryVM
            {
                Categories = _categoryService.All().OrderBy(c => c.Name).Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
            };
         
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            var model = new ProductVM
            {
               
                SubCategories = _subCategoryService.All().OrderBy(sc => sc.Name).Select(sc => new SelectListItem
                {
                    Value = sc.Id.ToString(),
                    Text = sc.Name
                }),

                ProductManufacturers = _productManufacturerService.All().OrderBy(pm => pm.Name).Select(pm => new SelectListItem
                {
                    Value = pm.Id.ToString(),
                    Text = pm.Name
                }),

                BrandModels = _brandModelsService.All().OrderBy(bm => bm.Name).Select(bm => new SelectListItem
                {
                    Value = bm.Id.ToString(),
                    Text = bm.Name
                })
            };

            return View(model);
        }

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Id = Guid.NewGuid();

            await _categoryService.AddAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubCategory(SubCategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                model = new SubCategoryVM
                {
                    Categories = _categoryService.All().OrderBy(c => c.Name).Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                };

                return View(model);
            }

            var entity = new SubCategory
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            };

            await _subCategoryService.AddAsync(entity); 
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductVM model)
        {
            if (!ModelState.IsValid)
            {
                model = new ProductVM
                {

                    SubCategories = _subCategoryService.All().OrderBy(sc => sc.Name).Select(sc => new SelectListItem
                    {
                        Value = sc.Id.ToString(),
                        Text = sc.Name
                    }),

                    ProductManufacturers = _productManufacturerService.All().OrderBy(pm => pm.Name).Select(pm => new SelectListItem
                    {
                        Value = pm.Id.ToString(),
                        Text = pm.Name
                    }),

                    BrandModels = _brandModelsService.All().OrderBy(bm => bm.Name).Select(bm => new SelectListItem
                    {
                        Value = bm.Id.ToString(),
                        Text = bm.Name
                    })
                };

                return View(model);
            }

            var entity = new Product
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                SpecificInfo1 = model.SpecificInfo1,
                SpecificInfo2 = model.SpecificInfo2,
                SpecificInfo3 = model.SpecificInfo3,
                SpecificInfo4 = model.SpecificInfo4,
                SpecificInfo5 = model.SpecificInfo5,
                SpecificInfo6 = model.SpecificInfo6,
                Price = model.Price,
                SubCategoryId = model.SubCategoryId,
                ProductManufacturerId = model.ProductManufacturerId
            };

            await _productService.AddAsync(entity);

            if (model.SelectedBrandModelIds != null && model.SelectedBrandModelIds.Count > 0)
            {
                foreach (var brandModelId in model.SelectedBrandModelIds.Distinct())
                {
                    await _brandModelProductJoinTableService.AddAsync(new BrandModelProductJoinTable
                    {
                        BrandModelId = brandModelId,
                        ProductId = entity.Id
                    });
                }
            }

            await _productService.SaveChangesAsync();

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

        [HttpGet]
        public async Task<IActionResult> EditCategories(Guid categoriesId)
        {
            var category = await _categoryService.All().Where(c => c.Id == categoriesId).Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name,
                ImageUrl = c.ImageUrl
            }).FirstOrDefaultAsync();

            if (category == null) { return NotFound(); }
            
            return View("Areas/Admin/Views/Catalog/Edit/EditCategory.cshtml", category);
        }

        [HttpGet]
        public async Task<IActionResult> EditSubCategory(Guid subCategoryId)
        {
            var subCategory = await _subCategoryService.All().Where(sc => sc.Id == subCategoryId).Select(sc => new SubCategoryVM
            {
                Id = sc.Id,
                Name = sc.Name,
                ImageUrl = sc.ImageUrl
            }).FirstOrDefaultAsync();

            if (subCategory == null) { return NotFound(); }

            return View("Areas/Admin/Views/Catalog/Edit/EditSubCategory.cshtml", subCategory);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(Guid productId)
        {
            var product = await _productService.All().Where(p => p.Id == productId).Select(p => new ProductVM
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Description = p.Description,
                SpecificInfo1 = p.SpecificInfo1,
                SpecificInfo2 = p.SpecificInfo2,
                SpecificInfo3 = p.SpecificInfo3,
                SpecificInfo4 = p.SpecificInfo4,
                SpecificInfo5 = p.SpecificInfo5,
                SpecificInfo6 = p.SpecificInfo6,
                Price = p.Price
            }).FirstOrDefaultAsync();

            if (product == null) { return NotFound(); }

            return View("Areas/Admin/Views/Catalog/Edit/EditProduct.cshtml", product);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategoriesConfirmed(CategoryVM model)
        {
            var edited = await _categoryService.All().FirstOrDefaultAsync(c => c.Id == model.Id);

            edited.Name = model.Name;

            edited.ImageUrl = model.ImageUrl;
           

            await _categoryService.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubCategoryConfirmed(SubCategoryVM model)
        {
            var edited = await _subCategoryService.All().FirstOrDefaultAsync(sc => sc.Id == model.Id);

            edited.Name = model.Name;

            edited.ImageUrl = model.ImageUrl;

            await _subCategoryService.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProductConfirmed(ProductVM model)
        {
            var edited = await _productService.All().FirstOrDefaultAsync(p => p.Id == model.Id);

            edited.Name = model.Name;

            edited.ImageUrl = model.ImageUrl;

            edited.Description = model.Description;

            edited.SpecificInfo1 = model.SpecificInfo1;

            edited.SpecificInfo2 = model.SpecificInfo2;

            edited.SpecificInfo3 = model.SpecificInfo3;

            edited.SpecificInfo4 = model.SpecificInfo4;

            edited.SpecificInfo5 = model.SpecificInfo5;

            edited.SpecificInfo6 = model.SpecificInfo6;

            edited.Price = model.Price;

            await _productService.SaveChangesAsync();

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

        [HttpGet]
        public async Task<IActionResult> DeleteCategories(Guid categoriesId)
        {
          var category = await _categoryService.All().Where(c => c.Id == categoriesId).FirstOrDefaultAsync();

            if (category == null) { return NotFound(); }

            return View("Areas/Admin/Views/Catalog/Delete/DeleteCategories.cshtml", category);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSubCategory(Guid subCategoryId)
        {
            var subCategory = await _subCategoryService.All().FirstOrDefaultAsync(sc => sc.Id == subCategoryId);

            if (subCategory == null) { return NotFound(); }

            return View("Areas/Admin/Views/Catalog/Delete/DeleteSubCategory.cshtml", subCategory);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var product = await _productService.All().FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null) { return NotFound(); }

            return View("Areas/Admin/Views/Catalog/Delete/DeleteProduct.cshtml", product);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteCategories")]
        public async Task<IActionResult> DeleteCategoriesConfirmed(Guid categoriesId)
        {
            await _categoryService.All().Where(c => c.Id == categoriesId).ExecuteDeleteAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteSubCategory")]
        public async Task<IActionResult> DeleteSubCategoryConfirmed(Guid subCategoryId)
        {
            await _subCategoryService.All().Where(sc => sc.Id == subCategoryId).ExecuteDeleteAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteProduct")]
        public async Task<IActionResult> DeleteProductConfirmed(Guid productId)
        {
            await _productService.All().Where(p => p.Id == productId).ExecuteDeleteAsync();

            return RedirectToAction(nameof(Index));
        } 
    }
}
