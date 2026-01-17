using System.Diagnostics;
using System.Threading.Tasks;
using GrandLineAuto.Data;
using GrandLineAuto.Data.Models;
using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using GrandLineAuto.Infrastructure.Services;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using GrandLineAuto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly GrandLineAutoDbContext _dbContext;

        public HomeController(IBrandService brandService, GrandLineAutoDbContext dbContext)
        {
            _brandService = brandService;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(string? q)
        {
            ViewBag.Query = q;
           
            var brands = await _brandService.GetBrands(q);

            return View(brands);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
