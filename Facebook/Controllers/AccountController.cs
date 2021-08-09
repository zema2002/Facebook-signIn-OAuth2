using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Owin.Security.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace Facebook.Controllers
{
    [AllowAnonymous, Route("account")]
    public class AccountController : Controller
    {
        [Route("google-login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("SignInGoogle") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }


        [Route("google-response")]

        //public IActionResult Secret()
        //{
        //    return View(this.User);
        //}

        public async Task<IActionResult> SignInGoogle()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [Route("google-info")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewBag.Name = HttpContext.User.Identity.Name;
            ViewBag.Email = HttpContext.User.Identity.IsAuthenticated;
            var check = HttpContext.User.Identity.IsAuthenticated;
            //if (check) { Response.Redirect("/Home/GoogleResponse"); }
            return View();

            }
            //public async Task<IActionResult> SignInGoogle()
            //{

            //    return View();
            //}

            public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page
            return LocalRedirect("/");
        }

      
        //}


        //    [Route("facebook-login")]
        //    public IActionResult FacebookLogin()
        //    {
        //        var properties = new AuthenticationProperties { RedirectUri = "/FacebookResponse" };
        //        return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        //    }

        //    [Route("facebook-response")]


        //    public async Task<IActionResult> FacebookResponse()
        //    {
        //        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //        ViewBag.Name = HttpContext.User.Identity.Name;
        //        ViewBag.Email = HttpContext.User.Identity.IsAuthenticated;
        //        var check = HttpContext.User.Identity.IsAuthenticated;
        //        if (check) { Response.Redirect("/Home/GoogleResponse"); }
        //        return View();

        //    }
        //}



        //    [HttpGet]
        //    [AllowAnonymous]
        //    public async Task<IActionResult> Login(string returnUrl) 
        //    {
        //        LoginViewModel model = new LoginViewModel 
        //        {
        //            ReturnUrl = returnUrl;
        //        ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        //    };
        //    return View(model); 
        //}

    } }



