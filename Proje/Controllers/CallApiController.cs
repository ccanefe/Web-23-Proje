using Microsoft.AspNetCore.Mvc;

namespace Proje.Controllers
{
    public class CallApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
