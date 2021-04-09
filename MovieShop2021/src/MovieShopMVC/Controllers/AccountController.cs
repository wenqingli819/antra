using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        # region get blank page
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        #endregion

        //fill info
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            var user = await _userService.RegisterUser(model);
            return View();
        }

        # region get blank page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        #endregion

        //fill info
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model, string returnUrl = null)
        {

            #region 1. check returnUrl
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Content("~/");
            }
            #endregion

            #region 2. validate user and get user object
            var user = await _userService.ValidateUser(model.Email, model.Password);
            #endregion

            #region 3. if user is null, add error to ModelState and return to current view
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Login attempt");
                return View();
            }
            #endregion

            #region  4. if user not null, continue for actual user and create cookie
            // cookie based Authentication
            // Identity(Claims), will be stored in cookie

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // Identity
            // Identity yourself with the above claims
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // creating the cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            #endregion

            #region 5. redirect to home page
            return LocalRedirect(returnUrl);
            #endregion
        }

        // logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(); // will delete the auth cookie, if not, use brute force
                                              // https://stackoverflow.com/questions/41122053/httpcontext-authentication-signoutasync-does-not-delete-auth-cookie
            return RedirectToAction("Login");
        }

    }
}
