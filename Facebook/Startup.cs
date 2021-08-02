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


            services.AddAuthentication(options => { options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; }).AddCookie(options => { options.LoginPath = "/account/google-login"; }).AddGoogle(options => { options.ClientId = "309849919056-4lbg428kdpdvo114960haacnah6obimn.apps.googleusercontent.com"; options.ClientSecret = "Sac_0TA6Z6QDAIaolL0mUOIU"; });




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
