using Microsoft.AspNetCore.Mvc;

namespace MvcWebApp.Controllers
{
    public class AccountController:Controller
    {
        [HttpGet]
        public IActionResult Login ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register(int i)
        {
            return View();
        }
    }
}
