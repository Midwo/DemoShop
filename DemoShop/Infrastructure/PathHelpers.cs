using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoShop.Infrastructure
{
    public static class PathHelpers
    {

        public static string Partners(this UrlHelper helper, string namePhoto)
        {
            var path = Path.Combine("~/Content/Partners/", namePhoto);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }

        public static string Overlays(this UrlHelper helper, string namePhoto)
        {
            var path = Path.Combine("~/Content/overlay/", namePhoto);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }

        public static string Products(this UrlHelper helper, string namePhoto)
        {
            var path = Path.Combine("~/Content/Products/", namePhoto);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }

        public static string IconsMenuProduct(this UrlHelper helper, string namePhoto)
        {
            var path = Path.Combine("~/Content/IconsMenuProduct/", namePhoto);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }

        public static string About(this UrlHelper helper, string namePhoto)
        {
            var path = Path.Combine("~/Content/About/", namePhoto);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}