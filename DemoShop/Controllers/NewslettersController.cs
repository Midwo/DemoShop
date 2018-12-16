using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoShop.DAL;
using DemoShop.Models;

namespace DemoShop.Controllers
{
    public class NewslettersController : Controller
    {
        private DemoShopContext db = new DemoShopContext();

        // GET: Newsletters
        public ActionResult Index()
        {
            return View(db.Newsletters.ToList());
        }

        // GET: Newsletters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newsletter newsletter = db.Newsletters.Find(id);
            if (newsletter == null)
            {
                return HttpNotFound();
            }
            return View(newsletter);
        }

        // GET: Newsletters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Newsletters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                var check = db.Newsletters.Where(a => a.Email == newsletter.Email);
                if (check.Count() < 1)
                {
                    newsletter.UnscribeCode = Guid.NewGuid().ToString();
                    UrlHelper u = new UrlHelper(this.ControllerContext.RequestContext);
                    string url = u.Action("UnscribePage", "Newsletters",  new { email = newsletter.Email, code = newsletter.UnscribeCode }, Request.Url.Scheme);
                    newsletter.UnscribeLink = url;
                    db.Newsletters.Add(newsletter);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }

            return View(newsletter);
        }

        // GET: Newsletters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newsletter newsletter = db.Newsletters.Find(id);
            if (newsletter == null)
            {
                return HttpNotFound();
            }
            return View(newsletter);
        }

        // POST: Newsletters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsletterID,Email,UnscribeCode")] Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsletter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsletter);
        }

        // GET: Newsletters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newsletter newsletter = db.Newsletters.Find(id);
            if (newsletter == null)
            {
                return HttpNotFound();
            }
            return View(newsletter);
        }

        // POST: Newsletters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Newsletter newsletter = db.Newsletters.Find(id);
            db.Newsletters.Remove(newsletter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST: Newsletters/Delete/5
        [HttpPost]
        public ActionResult Unscribe(string email, string code)
        {

            Newsletter newsletter = db.Newsletters.SingleOrDefault(i => i.Email == email && i.UnscribeCode == code);
            if (newsletter != null)
            {
                db.Newsletters.Remove(newsletter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Content("Błędne dane");
        }
        
        public ActionResult UnscribePage(string email, string code)
        {

            Newsletter newsletter = db.Newsletters.SingleOrDefault(i => i.Email == email && i.UnscribeCode == code);
            if (newsletter != null)
            {
                db.Newsletters.Remove(newsletter);
                db.SaveChanges();
                return Content("Usunięto adres email z listy newsletter");

            }
            return Content("Błędne dane");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
