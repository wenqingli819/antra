using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            #region my first logger
            //_logger.LogInformation("Logging non critical information {datetime}",DateTime.UtcNow);
            //try
            //{
            //    throw new Exception("my custom exception");
            //}
            //catch(Exception e)
            //{
            //    _logger.LogError("caught exception{datetime}", DateTime.UtcNow);
            //}
            #endregion

            // it will look for a view with name called Index(because the action method name is index)

            // passing data from controller to view, it has three options:
            // 1.ViewBag 2. ViewData 3. ** Strongly Typed Models
            // ref: https://www.c-sharpcorner.com/article/passing-data-from-controller-to-view-part-one/
            var topGrossingMovies = await _movieService.Get30HighestGrossing();
            return View(topGrossingMovies);
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
