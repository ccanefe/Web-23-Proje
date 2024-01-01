using Microsoft.AspNetCore.Mvc;

namespace Proje.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
