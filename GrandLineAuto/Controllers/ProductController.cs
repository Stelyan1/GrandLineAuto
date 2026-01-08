using GrandLineAuto.Data;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GrandLineAuto.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(Guid subCategoryId, Guid brandModelId)
        {
            var products = await _productService.GetProductForModelBySubCategoryId(subCategoryId, brandModelId);

            return View(products);
        }

        public async Task<IActionResult> Details(Guid productId)
        {
            var product = await _productService.DetailsProduct(productId);

            return View(product);
        }
    }
}
