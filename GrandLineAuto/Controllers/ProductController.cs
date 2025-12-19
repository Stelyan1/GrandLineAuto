using GrandLineAuto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GrandLineAuto.Controllers
{
    public class ProductController : Controller
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public ProductController(GrandLineAutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(Guid subCategoryId, Guid modelId)
        {
            var products = _dbContext.Products
                .Where(p => p.SubCategoryId == subCategoryId)
                .ToList();

            return View(products);
        }
    }
}
