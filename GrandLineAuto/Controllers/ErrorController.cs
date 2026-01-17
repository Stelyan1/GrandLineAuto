using Microsoft.AspNetCore.Mvc;

namespace GrandLineAuto.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }

        [Route("Error/StatusCode")]
        public IActionResult StatusCodePage(int code)
        {
            return code switch
            {
                401 => View("Unauthorized"),
                403 => View("Forbidden"),
                404 => View("NotFound"),
                _ => View("StatusCodeGeneric")
            };

        }
    }
}
