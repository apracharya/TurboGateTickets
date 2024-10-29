using Microsoft.AspNetCore.Mvc;

namespace TurboGateTickets.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
