using System.Security.Claims;
using System;
using System.Net;
using System.Threading.Tasks;
using Cinema.Controllers;
using Cinema.Dal.Data;
using Cinema.Dal.Dbo;
using Cinema.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNetCore.Authorization;

namespace Cinema.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<UsersDbo> _signInManager;
        private readonly UserManager<UsersDbo> _userManager;

        public AccountController(UserManager<UsersDbo> userManager,
                                SignInManager<UsersDbo> signInManager)
        {
            _userManager = userManager; 
            _signInManager = signInManager;

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UsersDbo user = new UsersDbo { UserName = model.Username, Email = model.Username };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("List", "Movie");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Code);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthenticateModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
            return View(model);
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}