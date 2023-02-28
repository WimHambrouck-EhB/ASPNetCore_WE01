using Microsoft.AspNetCore.Mvc;
using Werkcollege01.Models;

namespace Werkcollege01.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            // geen Index view voor deze controller, gebruiker doorsturen naar /Pizza/Bestellen
            return RedirectToAction(nameof(Bestellen));
        }

        public IActionResult Bestellen()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Toon([Bind("Besteller,Soort,ExtraKaas,Betaalwijze")] Pizza? pizza)
        {
            if (pizza == null) {
                return BadRequest("Invalid POST data");
            }

            List<string> errors = new();

            if (string.IsNullOrWhiteSpace(pizza.Besteller))
                errors.Add("Gelieve de naam van de besteller op te geven.");
            if (string.IsNullOrWhiteSpace(pizza.Soort))
                errors.Add("Gelieve de pizza die je wenst te bestellen op te geven.");
            if (string.IsNullOrWhiteSpace(pizza.Betaalwijze))
                errors.Add("Gelieve een betaalwijze te kiezen.");

            ViewBag.Errors = errors;

            return View(pizza);
        }
    }
}
