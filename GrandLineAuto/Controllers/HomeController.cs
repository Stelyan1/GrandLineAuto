using System.Diagnostics;
using System.Threading.Tasks;
using GrandLineAuto.Data;
using GrandLineAuto.Data.Models;
using GrandLineAuto.Infrastructure.Services;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using GrandLineAuto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaseService<Brand> _baseService;
        public HomeController(IBaseService<Brand> baseService)
        {
            _baseService = baseService;
        }

        public async Task<IActionResult> Index()
        {
            var brand = await _baseService.GetAllEntitiesAsync();

            return View(brand);
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
