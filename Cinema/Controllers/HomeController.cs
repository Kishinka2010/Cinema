using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Dal.Dbo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly UserManager<UsersDbo> _userManager;

        public HomeController(UserManager<UsersDbo> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            string userName = _userManager.GetUserName(User);
            return View("Index", userName);
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
