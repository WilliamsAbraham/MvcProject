using Microsoft.AspNetCore.Mvc;

namespace MvcWebApp.Controllers
{
    public class AccountController:Controller
    {
        [HttpGet]
        public IActionResult Register ()
        {
            return View();
        }
    }
}
