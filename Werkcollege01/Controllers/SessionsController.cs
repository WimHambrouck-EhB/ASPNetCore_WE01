using Microsoft.AspNetCore.Mvc;

namespace Werkcollege01.Controllers
{
    public class SessionsController : Controller
    {
        public const string KEY_AANTAL_BEZOEKEN = "_AantalBezoeken";

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32(KEY_AANTAL_BEZOEKEN) is not int teller)
            {
                teller = 0;
            }

            HttpContext.Session.SetInt32(KEY_AANTAL_BEZOEKEN, ++teller);

            ViewData[KEY_AANTAL_BEZOEKEN] = teller;

            return View();
        }
    }
}
