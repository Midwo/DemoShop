using DemoShop.DAL;
using DemoShop.Models;
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
            //Category newCategory = new Category { Title = "Miś", Description = "Coś", Active = true, FileNamePhoto = "jajko" };
            //db.Categories.Add(newCategory);
            //db.SaveChanges();
            var list = db.Categories.ToList();
            return View();
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