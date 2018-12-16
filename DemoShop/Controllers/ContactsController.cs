using DemoShop.DAL;
using DemoShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DemoShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactsController : Controller
    {
        private DemoShopContext db = new DemoShopContext();

        // GET: Contacts
        public ActionResult Index(bool? state)
        {
            if (!state.HasValue)
            {
                return View(db.Contacts.OrderByDescending(a => a.ContactID).ToList());
            }
            else if (state == true)
            {
                return View(db.Contacts.Where(a => a.SentAnswer == true).OrderByDescending(a => a.ContactID).ToList());

            }
            else
            {
                return View(db.Contacts.Where(a => a.SentAnswer == false).OrderByDescending(a => a.ContactID).ToList());

            }

        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? Contactid)
        {
            if (Contactid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(Contactid);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }


        //Create method is in HomeController

        //// GET: Contacts/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Contacts/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ContactID,Name,Email,Phone,Message,SentAnswer")] Contact contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Contacts.Add(contact);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(contact);
        //}

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? Contactid)
        {
            if (Contactid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(Contactid);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactID,Name,Email,Phone,Message,SentAnswer")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                // return RedirectToAction("Index", new { state = contact.SentAnswer });
                return RedirectToAction("Index", "Manage");

            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? Contactid)
        {
            if (Contactid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(Contactid);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Contactid)
        {
            Contact contact = db.Contacts.Find(Contactid);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
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