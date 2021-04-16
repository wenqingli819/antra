using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;

namespace MovieShopMVC.Controllers
{
    public class CastsController : Controller
    {
 
        private readonly ICastService _castService;
        private readonly IMovieService _movieService;
        public CastsController(IMovieService movieService, ICastService castService)
        {
            _movieService = movieService;
            _castService = castService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var cast = await _castService.GetCastDetailByMovieId(id);
            var moviesByCast = await _movieService.GetMoviesByCast(id);
            return View(moviesByCast);
        }
    }
}
