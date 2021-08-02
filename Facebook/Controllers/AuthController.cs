using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        [Route("signin")]
        public IActionResult SignIn_Facebook()
        {
            
            return Challenge(new AuthenticationProperties{RedirectUri="/"});
        }

        public IActionResult SignIn_Google()
        {
            
            return Challenge(new AuthenticationProperties { RedirectUri = "/" });
            
        }

       

        
    }
}
