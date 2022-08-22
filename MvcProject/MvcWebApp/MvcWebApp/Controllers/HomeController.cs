using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using MvcWebApp.Models;
using System.Diagnostics;
using WebData.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MvcWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;


        public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {

            //if (_signInManager.IsSignedIn(User))
             return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}