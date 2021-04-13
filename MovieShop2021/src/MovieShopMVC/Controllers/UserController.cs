using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserPurchasedMovies()
        {
            return View();
        }

        [Authorize]     
        [HttpPost]
        public async Task<IActionResult> PurchaseMovie()
        {
            return View();
        }
    }
}
