using Microsoft.AspNetCore.Mvc;

namespace Werkcollege01.Controllers
{
    public class GebruikersController : Controller
    {
        public const string KEY_GEBRUIKER = "_Gebruiker";

        public IActionResult Index()
        {
            // geen indexpagina in deze controller, gebruiker doorsturen naar /Gebruikers/Invoer
            return RedirectToAction(nameof(Invoer));
        }

        public IActionResult Invoer()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Foutmelding = TempData["Message"];
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Invoer(string? gebruikersnaam)
        {
            if (string.IsNullOrWhiteSpace(gebruikersnaam))
            {
                ViewBag.Foutmelding = "Gelieve een gebruikersnaam in te voeren.";
            }
            else
            {
                HttpContext.Session.SetString(KEY_GEBRUIKER, gebruikersnaam);
                return RedirectToAction(nameof(Toon));
            }

            return View();
        }

        public IActionResult Toon()
        {
            string? gebruikersnaam = HttpContext.Session.GetString(KEY_GEBRUIKER);

            if (gebruikersnaam == null)
            {
                TempData["Message"] = "Nog geen gebruikersnaam ingevoerd...";

                return RedirectToAction(nameof(Invoer));
            }

            ViewBag.Gebruiker = gebruikersnaam;
            return View();
        }
    }
}
