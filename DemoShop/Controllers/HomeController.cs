using DemoShop.DAL;
using DemoShop.Models;
using DemoShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoShop.Controllers
{
    public class HomeController : Controller
    {
        private DemoShopContext db = new DemoShopContext(); 
        public ActionResult Index()
        {

            var categories = db.Categories.Where(a => a.Active == true).ToList();
            var theBestProducts = db.Products.Where(a => a.Active == true && a.TheBestProduct == true).OrderBy(a => Guid.NewGuid()).Take(4).ToList();
            var newProducts = db.Products.Where(a => a.Active == true).OrderByDescending(a => a.AddDate).OrderByDescending(a => a.AddDate).Take(4).ToList();
            var promotions = db.Products.Where(a => a.Active == true && a.Promotion == true).OrderBy(a => Guid.NewGuid()).Take(4).ToList();

            foreach (var item in theBestProducts)
            {
                item.Description = item.Description.Substring(0, 80) + "[...]";
                if (item.ProductTitle.Length >= 24)
                {
                    item.ProductTitle = item.ProductTitle.Substring(0, 24) + "[...]";
                }
            }

            foreach (var item in promotions)
            {
                item.Description = item.Description.Substring(0, 80) + "[...]";
                if (item.ProductTitle.Length >= 24)
                {
                    item.ProductTitle = item.ProductTitle.Substring(0, 24) + "[...]";
                }
            }

            foreach (var item in newProducts)
            {
                item.Description = item.Description.Substring(0, 80) + "[...]";
                if (item.ProductTitle.Length >= 24)
                {
                    item.ProductTitle = item.ProductTitle.Substring(0, 24) + "[...]";
                }
            }

            var mergeViewModel = new HomeViewModel
            {
                Categories = categories,
                TheBestProducts = theBestProducts,
                NewProducts = newProducts,
                Promotions = promotions
            };

        

            return View(mergeViewModel);
        }

        public ActionResult ViewWithInformation(string viewname)
        {
            //ViewBag.Message = "Your application description page.";

            return View(viewname);
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}