using DemoShop.DAL;
using DemoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoShop.Controllers
{
    public class StoreController : Controller
    {
        
       DemoShopContext db = new DemoShopContext();

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult Details(int id)
        {
            //var Product = db.Products.Find(id);
            var Product = db.Products.Where(a => a.ProductID == id).Where(a=>a.Active == true).Single();
            return View(Product);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminDetails(int id)
        {
            //var Product = db.Products.Find(id);
            var Product = db.Products.Where(a => a.ProductID == id).Where(a => a.Active == false).Single();
            return View("Details", Product);
        }
        public ActionResult ProductList(string categoryname, string searchQuery = null)
        {
            TempData["SelectCategory"] = categoryname;
            List<Product> ProductList;
            var List = db.Categories.Include("Products").Where(a => a.Title.ToUpper() == categoryname.ToUpper()).Single();
            if (searchQuery == null)
            {
                ProductList = List.Products.Where(a => a.Active == true).ToList();
            }
            else
            {
                ProductList = List.Products.Where(a => a.ProductTitle.ToLower().Contains(searchQuery.ToLower()) && a.Active == true).ToList();
            }
            foreach (var item in ProductList)
            {
                if (item.Description.Length >= 60)
                {
                    item.Description = item.Description.Substring(0, 60) + "[...]";
                }
                if (item.ProductTitle.Length >= 24)
                {
                    item.ProductTitle = item.ProductTitle.Substring(0, 24) + "[...]";
                }
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProductList", ProductList);
            }

            return View(ProductList);
        }

        //Enable only with html action
        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult CategoryList()
        {
            var categoryList = db.Categories.Where(a => a.Active == true).ToList();
            
            //_CategoryList beacuse we have patrial with this name 
            return PartialView("_CategoryList", categoryList);
        }

        public ActionResult ProductAutocomplete(string term)
        {
            string CategoryName = TempData["SelectCategory"].ToString();
            TempData.Keep();
            var ListProduct = db.Categories.Include("Products").Where(a => a.Title.ToUpper() == CategoryName.ToUpper()).Single();
            var product = ListProduct.Products.Where(a => a.Active == true && a.ProductTitle.ToLower().Contains(term.ToLower())).Take(5).Select(a => new { label = a.ProductTitle });
            return Json(product, JsonRequestBehavior.AllowGet);

        }

    }
}