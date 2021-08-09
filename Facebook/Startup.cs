using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;


namespace Facebook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultChallengeScheme = FacebookDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            //    .AddFacebook(options =>
            //    {
            //        options.AppId = "260346258851292";
            //        options.AppSecret = "60990bcb7f4f15f1f25f60fb44de2a8d";
            //        options.ClientId.ToString();

            //    }).AddCookie();

            // services.AddIdentity<IdentityUser, IdentityRole>();
            //services.AddAuthentication(options => { options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; })
            // .AddCookie(options => { options.LoginPath = "/account/facebook-login"; })
            // .AddFacebook(options => {
            //     options.AppId = "260346258851292";
            //     options.AppSecret = "60990bcb7f4f15f1f25f60fb44de2a8d";
            //    // options.ClientSecret = "Sac_0TA6Z6QDAIaolL0mUOIU";
            //     options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            //     // options.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
            //     options.ClaimActions.MapJsonKey(ClaimTypes.Name, "Name");
            //     // options.ClaimActions.MapJsonKey(ClaimTypes.Gender, "Gender");
            //     options.ClaimActions.MapJsonKey(ClaimTypes.MobilePhone, "MobilePhone");
            //     options.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "givenName");
            //     options.ClaimActions.MapJsonKey(ClaimTypes.Surname, "surname");
            //     options.ClaimActions.MapJsonKey("urn:google:profile", "link");
            //     options.ClaimActions.MapJsonKey(ClaimTypes.Email, "Email");
            //     options.ClaimActions.MapJsonKey("image", "picture");
            //     options.SaveTokens = true;
            //     // options.Scope.Add("https://www.googleapis.com/auth/userinfo.profile");

            //     options.Events.OnCreatingTicket = (context) =>
            //     {
            //         var GN = context.User.GetProperty("given_name").GetString();
            //         //var gender= context.User.GetProperty("gender").GetString();
            //         /// var mobile_phone = context.User.GetProperty("mobile_phone").GetString();
            //         var LK = context.User.GetProperty("locale").GetString();
            //         var SN = context.User.GetProperty("family_name").GetString();
            //         var Id = context.User.GetProperty("id").GetString();
            //         var Email = context.User.GetProperty("email").GetString();
            //         var picture = context.User.GetProperty("picture").GetString();
            //         context.Identity.AddClaim(new Claim("email", Email));
            //         context.Identity.AddClaim(new Claim("id", Id));
            //         context.Identity.AddClaim(new Claim("GivenName", GN));
            //         context.Identity.AddClaim(new Claim("FamilyName", SN));
            //         context.Identity.AddClaim(new Claim("locale", LK));
            //         // context.Identity.AddClaim(new Claim("gender", gender));
            //         // context.Identity.AddClaim(new Claim("mobile_phone", mobile_phone));
            //         // context.Identity.AddClaim(new Claim("Email", Email));
            //         //var email = context.User.GetProperty("email").GetString();
            //         // var t = context.User.ValueKind.ToString();
            //         //var ex= load.RootElement.GetProperty("access_token").GetString();

            //         context.Identity.AddClaim(new Claim("picture", picture));


            //         return Task.CompletedTask;
            //     };


            // });










































            services.AddAuthentication(options => { options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = "External";
            })
                .AddCookie(options => { options.LoginPath = "/account/google-login"; })
                .AddCookie("External")
            .AddGoogle(options => { options.ClientId = "309849919056-4lbg428kdpdvo114960haacnah6obimn.apps.googleusercontent.com";
                options.ClientSecret = "Sac_0TA6Z6QDAIaolL0mUOIU";
                options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier,"id");
               // options.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
                options.ClaimActions.MapJsonKey(ClaimTypes.Name, "Name");
               // options.ClaimActions.MapJsonKey(ClaimTypes.Gender, "Gender");
                options.ClaimActions.MapJsonKey(ClaimTypes.MobilePhone, "MobilePhone");
                options.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "givenName");
                options.ClaimActions.MapJsonKey(ClaimTypes.Surname, "surname");
                options.ClaimActions.MapJsonKey("urn:google:profile", "link");
                options.ClaimActions.MapJsonKey(ClaimTypes.Email, "Email");
                options.ClaimActions.MapJsonKey("image", "picture");
                options.SaveTokens = true;
                // options.Scope.Add("https://www.googleapis.com/auth/userinfo.profile");
                
                options.Events.OnCreatingTicket = (context) =>
                {
                    var GN = context.User.GetProperty("given_name").GetString();
                    //var gender= context.User.GetProperty("gender").GetString();
                   /// var mobile_phone = context.User.GetProperty("mobile_phone").GetString();
                    var LK = context.User.GetProperty("locale").GetString();
                    var SN = context.User.GetProperty("family_name").GetString();
                    var Id = context.User.GetProperty("id").GetString();
                    var Email = context.User.GetProperty("email").GetString();
                    var picture = context.User.GetProperty("picture").GetString();
                    context.Identity.AddClaim(new Claim("email", Email));
                    context.Identity.AddClaim(new Claim("id", Id));
                    context.Identity.AddClaim(new Claim("GivenName", GN));
                    context.Identity.AddClaim(new Claim("FamilyName", SN));
                    context.Identity.AddClaim(new Claim("locale", LK));
                   // context.Identity.AddClaim(new Claim("gender", gender));
                   // context.Identity.AddClaim(new Claim("mobile_phone", mobile_phone));
                    // context.Identity.AddClaim(new Claim("Email", Email));
                    //var email = context.User.GetProperty("email").GetString();
                    // var t = context.User.ValueKind.ToString();
                    //var ex= load.RootElement.GetProperty("access_token").GetString();

                    context.Identity.AddClaim(new Claim("picture", picture));
                    

                    return Task.CompletedTask;
                };



                //options.Events.OnCreatingTicket = (context) =>
                //{
                //    var link = context.User.GetProperty("link").GetString();
                //    context.Identity.AddClaim(new Claim("link", link));
                //    //context.Identity.AddClaim(new Claim("Email", Email));
                //    return Task.CompletedTask;
                //};

                //options.Events.OnCreatingTicket = (context) =>
                //{
                //    var Email = context.User.GetProperty("email").GetString();
                //    context.Identity.AddClaim(new Claim("email", Email));
                //    //context.Identity.AddClaim(new Claim("Email", Email));
                //    return Task.CompletedTask;
                //};


            });




            //services.AddAuthentication(options =>
            //{
            //    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            //    //options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    //options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            //    .AddGoogle(options =>
            //    {

            //        options.ClientId = "309849919056-4lbg428kdpdvo114960haacnah6obimn.apps.googleusercontent.com";
            //        options.ClientSecret = "Sac_0TA6Z6QDAIaolL0mUOIU";
                //});
                //.AddFacebook(options =>
                //{
                //    options.AppId = "260346258851292";
                //    options.AppSecret = "60990bcb7f4f15f1f25f60fb44de2a8d";
                //});





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
