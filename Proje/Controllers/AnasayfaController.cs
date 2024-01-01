using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Proje.Services;

namespace Proje.Controllers
{
    public class AnasayfaController : Controller
    {
        private readonly ILogger<AnasayfaController> _logger;
        private LanguageService _localization;
        public AnasayfaController(ILogger<AnasayfaController> logger, LanguageService localization)
        {
            _logger = logger;
            _localization = localization;
        }
        public IActionResult AnasayfaGoruntule()
        {
            ViewBag.Welcome = _localization.Getkey("Welcome").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}