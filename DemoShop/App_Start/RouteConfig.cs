using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DemoShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProductDetails",
                url: "produkt-{id}.html",
                defaults: new { controller = "Store", action = "Details" }
                );

            routes.MapRoute(
                name: "BusinessInformation",
                url: "informacje/{viewname}",
                defaults: new { controller = "Home", action = "ViewWithInformation" }
                );

            routes.MapRoute(
                name: "CategoryList",
                url: "kategorie/{categoryname}",
                defaults: new {controller = "Store", action = "CategoryList" },
                constraints: new { categoryname = @"[\w ]+" }
                );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
