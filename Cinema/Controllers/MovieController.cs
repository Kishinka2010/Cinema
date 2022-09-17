using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Dal.interfaces;

namespace Cinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IAllMovie _allMovie;
        private readonly ISessionMovie _sessionMovie;

        public MovieController(ILogger<MovieController> logger, IAllMovie allMovie, ISessionMovie sessionMovie)
        {
            _logger = logger;
            _allMovie = allMovie;
            _sessionMovie = sessionMovie;
        }

        public ViewResult List()
        {
            MovieListViewModel movie = new MovieListViewModel();
            movie.Movies = _allMovie.Movies;
            return View(movie);
        }

        public IActionResult Index()
        {
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
