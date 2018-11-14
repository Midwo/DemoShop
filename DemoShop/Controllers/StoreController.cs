using DemoShop.DAL;
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
            return View();
        }

        public ActionResult ProductList(string categoryname)
        {
            var List = db.Categories.Include("Products").Where(a => a.Title == categoryname).Single();
            var ProductList = List.Products.Where(a=>a.Active == true).ToList();

            return View(ProductList);
        }

        //Enable only with html action
        [ChildActionOnly]
        public ActionResult CategoryList()
        {
            var categoryList = db.Categories.Where(a => a.Active == true).ToList();
            
            //_CategoryList beacuse we have patrial with this name 
            return PartialView("_CategoryList", categoryList);
        }


    }
}