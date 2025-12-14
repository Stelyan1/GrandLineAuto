using System.Diagnostics;
using GrandLineAuto.Data;
using GrandLineAuto.Data.Models;
using GrandLineAuto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly GrandLineAutoDbContext _dbContext;
        public HomeController(GrandLineAutoDbContext dbContext)
        {
            
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var brands = _dbContext.Brands.AsNoTracking();

            var model = brands.OrderBy(b => b.Name).Select(b => new Brand
            {
                Id = b.Id,
                Name = b.Name,
                ImageUrl = b.ImageUrl
            })
                .ToList();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
