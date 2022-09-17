using System.Security.Claims;
using System;
using System.Net;
using System.Threading.Tasks;
using Cinema.Dal.Data;
using Cinema.Dal.Dbo;
using Cinema.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security;

namespace AspNetIdentityApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly CinemaDbContext _context;
        private readonly SignInManager<UsersDbo> _signInManager;
        private readonly UserManager<UsersDbo> _userManager;

        public AccountController(CinemaDbContext context, UserManager<UsersDbo> userManager,
                                SignInManager<UsersDbo> signInManager)
        {
            _context = context;
            _userManager = userManager; 
            _signInManager = signInManager;

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(AuthenticateModel model)
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

        //[HttpPost("authenticate")]
        //public async Task<ActionResult<UserInfoDto>> Authenticate([FromBody] AuthenticateModel model)
        //{
        //    var user = await _context.Employees
        //        .Include(e => e.EmployeeRoles).ThenInclude(e => e.Role)
        //        .FirstOrDefaultAsync(e => e.Email == model.Username);

        //    if (user == null)
        //        return BadRequest("Incorrect user email.");

        //    var authorizationResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
        //    if (!authorizationResult.Succeeded)
        //        return BadRequest("Login or password is incorrect");

        //    var userRoles = user.EmployeeRoles
        //        .Select(e => e.Role.Title)
        //        .ToList();

        //    return Ok(UserInfoDto.Create(user, userRoles));
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(UsersDbo model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ApplicationUser user = await _userManager.FindAsync(model.Email, model.Password);
        //        if (user == null)
        //        {
        //            ModelState.AddModelError("", "Неверный логин или пароль.");
        //        }
        //        else
        //        {
        //            ClaimsIdentity claim = await _userManager.CreateIdentityAsync(user,
        //                                    DefaultAuthenticationTypes.ApplicationCookie);
        //            AuthenticationManager.SignOut();
        //            AuthenticationManager.SignIn(new AuthenticationProperties
        //            {
        //                IsPersistent = true
        //            }, claim);
        //            if (String.IsNullOrEmpty(returnUrl))
        //                return RedirectToAction("Index", "Home");
        //            return Redirect(returnUrl);
        //        }
        //    }
        //    ViewBag.returnUrl = returnUrl;
        //    return View(model);
        //}
        //public ActionResult Logout()
        //{
        //    AuthenticationManager.SignOut();
        //    return RedirectToAction("Login");
        //}
    }
}