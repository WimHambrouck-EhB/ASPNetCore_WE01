using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace Werkcollege01.Controllers
{
    public class RegistreerController : Controller
    {
        private readonly ImmutableList<string> _mailClients =
            ImmutableList.Create(
                "Microsoft Outlook",
                "Outlook Express",
                "Thunderbird",
                "Other…"
            );

        public IActionResult Index()
        {
            ViewBag.MailClients = _mailClients;
            return View();
        }

        [HttpPost]
        public IActionResult Registreer(string? email, int mailclient, string? wachtwoord)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(wachtwoord))
            {
                ViewBag.Message = "Registratie succesvol!";
            }

            ViewBag.Email = email;
            ViewBag.Client = _mailClients[mailclient];
            ViewBag.MailClients = _mailClients;

            return View("Index");
        }
    }
}
