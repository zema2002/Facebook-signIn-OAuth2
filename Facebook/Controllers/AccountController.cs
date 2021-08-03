using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
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
    {[Route("google-login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [Route("google-response")]

        public IActionResult Secret()
        {
            return View(this.User);
        }

        public async Task<IActionResult> GoogleResponse() {
            // ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });
            ViewBag.Name = HttpContext.User.Identity.Name;
            ViewBag.Other = HttpContext.User.Claims.FirstOrDefault().Value;
            ViewBag.Email = HttpContext.User.Identity.IsAuthenticated;
            // ViewBag.Other = HttpContext.User.Identities.FirstOrDefault().Claims;
            //ViewBag.Other = HttpContext.User.Claims.FirstOrDefault().Value;
            /// var info = await _signInManager.GetExternalLoginInfoAsunc();
            /// var picture = info.Principal.FindFirstValue("image");
            //var info = await AuthenticationManager.GetExternalLoginInfoAsync();
            //var detailed = AuthenticationManager.AuthenticateAsync(DefaultAuthenticationTypes.ExternalCookie)
            //var googleUser = new GoogleOAuth2AuthenticationOptions {
                
            //}


            return View();


        }



        //public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        //{
        //   private readonly SignInManager<User> _signInManager;
        //ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
        //    SignInResult signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
        //    string email = info.Principal.FindFirstValue(ClaimTypes.Email);
        //    string firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName);
        //    string lastName = info.Principal.FindFirstValue(ClaimTypes.Surname);
        //    //
        //}



    }
}
