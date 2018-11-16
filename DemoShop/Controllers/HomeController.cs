using DemoShop.DAL;
using DemoShop.Infrastructure;
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
            List<Product> ListProduct;
            List<Category> ListCategory;
            InterfaceCacheProvider cache = new DefaultCacheProvider();


            if (cache.CheckSet(CacheNamespace.ListCategory))
            {

                ListCategory = cache.Get(CacheNamespace.ListCategory) as List<Category>;
            }
            else
            {
                ListCategory = db.Categories.Where(a => a.Active == true).ToList();
                cache.Set(CacheNamespace.ListCategory, ListCategory, 3600);
            }
            var categories = ListCategory;

            if (cache.CheckSet(CacheNamespace.BestProduct))
            {
                ListProduct = cache.Get(CacheNamespace.BestProduct) as List<Product>;
                ListProduct = ListProduct.OrderBy(a => Guid.NewGuid()).ToList();
            }
            else
            {
                ListProduct = db.Products.Where(a => a.Active == true && a.TheBestProduct == true).OrderBy(a => Guid.NewGuid()).ToList();

                foreach (var item in ListProduct)
                {
                    if (item.Description.Length >= 80)
                    {
                        item.Description = item.Description.Substring(0, 80) + "[...]";
                    }
                    if (item.ProductTitle.Length >= 24)
                    {
                        item.ProductTitle = item.ProductTitle.Substring(0, 24) + "[...]";
                    }
                }
                cache.Set(CacheNamespace.BestProduct, ListProduct, 3600);
            }
            var theBestProducts = ListProduct.Take(4);


            if (cache.CheckSet(CacheNamespace.NewProductFourActiveRecords))
            {
                ListProduct = cache.Get(CacheNamespace.NewProductFourActiveRecords) as List<Product>;
                ListProduct = ListProduct.OrderBy(a => Guid.NewGuid()).ToList();     
            }
            else
            {
                ListProduct = db.Products.Where(a => a.Active == true).OrderBy(a=> Guid.NewGuid()).Take(4).ToList();
                foreach (var item in ListProduct)
                {
                    if (item.Description.Length >= 80)
                    {
                        item.Description = item.Description.Substring(0, 80) + "[...]";
                    }
                    if (item.ProductTitle.Length >= 24)
                    {
                        item.ProductTitle = item.ProductTitle.Substring(0, 24) + "[...]";
                    }
                }
                cache.Set(CacheNamespace.NewProductFourActiveRecords, ListProduct, 3600);
            }
            var newProducts = ListProduct;

            if (cache.CheckSet(CacheNamespace.ProductsPromotions))
            {
                ListProduct = cache.Get(CacheNamespace.ProductsPromotions) as List<Product>;
                ListProduct = ListProduct.OrderBy(a => Guid.NewGuid()).ToList();
            }
            else
            {
                ListProduct = db.Products.Where(a => a.Active == true && a.Promotion == true).OrderBy(a => Guid.NewGuid()).ToList();
                foreach (var item in ListProduct)
                {
                    if (item.Description.Length >= 80)
                    {
                        item.Description = item.Description.Substring(0, 80) + "[...]";
                    }
                    if (item.ProductTitle.Length >= 24)
                    {
                        item.ProductTitle = item.ProductTitle.Substring(0, 24) + "[...]";
                    }
                }
                cache.Set(CacheNamespace.ProductsPromotions, ListProduct, 3600);
            }
            var promotions = ListProduct.Take(4);


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