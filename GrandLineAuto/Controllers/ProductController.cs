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

        public IActionResult Index(Guid productId)
        {
            var products = _dbContext.Products
                .AsNoTracking()
                .Where(p => p.SubCategoryId == productId)
                .OrderBy(p => p.Name)
                .ToList();

            return View(products);
        }
    }
}
