using Microsoft.AspNetCore.Mvc;

namespace GrandLineAuto.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
