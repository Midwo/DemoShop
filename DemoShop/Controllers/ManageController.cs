using DemoShop.App_Start;
using DemoShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DemoShop.Controllers
{
    public class ManageController : Controller
    {
       
        public async Task<ActionResult> ProfileAddress()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }

            return View(user.UserInformation);
        }

        public ActionResult Index()
        {
            return View();
        }
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeProfile(UserInformation userData)
        {
            if (ModelState.IsValid)
            {

                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.UserInformation = userData;
                var result = await UserManager.UpdateAsync(user);

                AddErrors(result);

            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

    }
}