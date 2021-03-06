﻿using DemoShop.DAL;
using DemoShop.Infrastructure;
using DemoShop.Models;
using DemoShop.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoShop.Controllers
{
    public class HomeController : Controller
    {
        //log with NLOG
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private DemoShopContext db = new DemoShopContext();
        private IMailService mailService;
        public HomeController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        public ActionResult Index(bool? error)
        {
            List<Product> ListProduct;
            List<Category> ListCategory;
            InterfaceCacheProvider cache = new DefaultCacheProvider();

            logger.Info("Ktoś wszedł na stronę");

            if (cache.CheckSet(CacheNamespace.ListCategory))
            {

                ListCategory = cache.Get(CacheNamespace.ListCategory) as List<Category>;
            }
            else
            {
                ListCategory = db.Categories.Where(a => a.Active == true).ToList();
                cache.Set(CacheNamespace.ListCategory, ListCategory, 10);
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
                cache.Set(CacheNamespace.BestProduct, ListProduct, 10);
            }
            var theBestProducts = ListProduct.Take(4);


            if (cache.CheckSet(CacheNamespace.NewProductFourActiveRecords))
            {
                ListProduct = cache.Get(CacheNamespace.NewProductFourActiveRecords) as List<Product>;
                ListProduct = ListProduct.OrderBy(a => Guid.NewGuid()).ToList();
            }
            else
            {
                ListProduct = db.Products.Where(a => a.Active == true).OrderByDescending(a => a.AddDate).Take(4).ToList();
                ListProduct = ListProduct.OrderBy(a => Guid.NewGuid()).ToList();
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
                cache.Set(CacheNamespace.NewProductFourActiveRecords, ListProduct, 10);
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
                cache.Set(CacheNamespace.ProductsPromotions, ListProduct, 10);
            }
            var promotions = ListProduct.Take(4);


            var mergeViewModel = new HomeViewModel
            {
                Categories = categories,
                TheBestProducts = theBestProducts,
                NewProducts = newProducts,
                Promotions = promotions
            };

            if (error == true)
            {
                ModelState.AddModelError("EmailError", "Błedny adres Email");
            }

            return View(mergeViewModel);
        }

        public ActionResult ViewWithInformation(string viewname)
        {
            //ViewBag.Message = "Your application description page.";

            return View(viewname);
        }

        // POST: Home/CreateContact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContact([Bind(Include = "ContactID,Name,Email,Phone,Message,SentAnswer")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View("kontakt");
        }
        // GET:  Home/CreateContact
        public ActionResult CreateContact()
        {
            return View("kontakt");
        }
        public ActionResult SavedNewsletter()
        {
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavedNewsletter(Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                var check = db.Newsletters.Where(a => a.Email == newsletter.Email);
                if (check.Count() < 1)
                {
                    newsletter.UnscribeCode = Guid.NewGuid().ToString();
                    this.mailService.SendNewsletterWelcomeEmail(newsletter);
                    UrlHelper u = new UrlHelper(this.ControllerContext.RequestContext);
                    string url = u.Action("UnscribePage", "Manage", new { email = newsletter.Email, code = newsletter.UnscribeCode }, Request.Url.Scheme);
                    newsletter.UnscribeLink = url;
                    db.Newsletters.Add(newsletter);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            bool error = true;
            return RedirectToAction("Index", "Home", new { error });
        }

    }
}