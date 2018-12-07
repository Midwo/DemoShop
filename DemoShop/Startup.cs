using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DemoShop.Startup))]

namespace DemoShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration
            .UseSqlServerStorage("DemoShopContext");

            //this call placement is important
            var options = new DashboardOptions
            {
                Authorization = new[] { new CustomAuthorizationFilter() }
            };
            app.UseHangfireDashboard("/hangfire", options);
            app.UseHangfireServer();
        }
        public class CustomAuthorizationFilter : IDashboardAuthorizationFilter
        {

            public bool Authorize(DashboardContext context)
            {
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    return true;
                }

                return false;
            }
        }
    }
}