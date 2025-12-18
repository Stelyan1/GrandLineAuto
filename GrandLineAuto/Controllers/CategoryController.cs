using GrandLineAuto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Controllers
{
    public class CategoryController : Controller
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public CategoryController(GrandLineAutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var categories = _dbContext.Categories.AsNoTracking().ToList();

            return View(categories);
        }
    }
}
