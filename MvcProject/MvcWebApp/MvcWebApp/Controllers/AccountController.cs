﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcWebApp.Models;
using WebData.Data.Entities;

namespace MvcWebApp.Controllers
{
    public class AccountController:Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [HttpGet]
        public IActionResult Login (string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
         
        }
        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
           if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(model.ReturnUrl);
                }
                
            }
            ModelState.AddModelError("", "Login Failed");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var user = new User { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index","Home");
            }
           else
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View();
        }
    }
}
