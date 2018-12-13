using DemoShop.App_Start;
using DemoShop.DAL;
using DemoShop.Infrastructure;
using DemoShop.Models;
using DemoShop.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DemoShop.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private DemoShopContext db = new DemoShopContext();
        private IMailService mailService;
        
        public ManageController(IMailService mailService)
        {
            this.mailService = mailService;
        }


        public async Task<ActionResult> ProfileAddress(ManageMessageId? message)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }

            ViewBag.StatusMessage =
             message == ManageMessageId.SavedInformation ? "Zapisano zmiany"
             : message == ManageMessageId.Error ? "Błąd - nie wykonano operacji"
             : "";

            return View(user.UserInformation);
        }


        public ActionResult Index(ManageMessageId? message)
        {
            logger.Info("Włączono panel zarządzania kontami");
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Hasło zostało zmienione"
                : message == ManageMessageId.SetPasswordSuccess ? "Hasło zostało ustawione"
                : message == ManageMessageId.Error ? "Błąd - nie wykonano operacji"
                : "";

            var model = new OtherLogInViewModel();
            if (User.Identity.Name == "klient@mdwojak.pl")
            {
                model = new OtherLogInViewModel
                {
                    HasPassword = HasPassword(),
                    isAdmin = User.IsInRole("Admin"),
                    isUserClient = true

                };
            }
            else
            {
                model = new OtherLogInViewModel
                {
                    HasPassword = HasPassword(),
                    isAdmin = User.IsInRole("Admin"),
                    isUserClient = false
                };
            }


            return View(model);
        }
        public async Task<ActionResult> OtherLogIn()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();

            var model = new OtherLogInViewModel
            {
                OtherLogins = otherLogins,
                CurrentLogins = userLogins,
                ShowRemoveButton = user.PasswordHash != null || otherLogins.Count > 1
            };

            return View(model);
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
            ManageMessageId message;
            if (ModelState.IsValid)
            {

                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.UserInformation = userData;
                var result = await UserManager.UpdateAsync(user);
                message = ManageMessageId.SavedInformation;
                AddErrors(result);

            }
            else
            {
                message = ManageMessageId.Error;

            }

            if (!ModelState.IsValid)
            {
                message = ManageMessageId.Error;
                //TempData["ViewData"] = ViewData;
                return RedirectToAction("ProfileAddress", new { Message = message });
            }

            return RedirectToAction("ProfileAddress", new { Message = message });
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                //return RedirectToAction("Index", new { Message = ManageMessageId.Error });
                return RedirectToAction("Index");
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            //return result.Succeeded ? RedirectToAction("Index", new { Message = ManageMessageId.LinkSuccess }) : RedirectToAction("Index", new { Message = ManageMessageId.Error });
            return result.Succeeded ? RedirectToAction("Index") : RedirectToAction("Index");

        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            LinkSuccess,
            Error,
            SavedInformation
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            //ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                //message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                //message = ManageMessageId.Error;
            }
            //return RedirectToAction("OtherLogIn", new { Message = message });
            return RedirectToAction("OtherLogIn");
        }
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (User.Identity.Name == "admin@mdwojak.pl" || User.Identity.Name == "klient@mdwojak.pl")
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }


        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        private ApplicationSignInManager _signInManager;
        public ManageController()
        {
        }

        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        // All 
        public ActionResult ViewOfOrderHistory()
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Order> userOrders;
            userOrders = db.Orders.Where(p => p.UserId == userId).Include("OrderItems").OrderByDescending(a => a.DateCreated).Take(20);
            return View(userOrders);
        }

        public ActionResult WaitingViewOfOrderHistory()
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Order> userOrders;
            userOrders = db.Orders.Where(p => p.UserId == userId).Where(a => a.State == State.New).Include("OrderItems").OrderByDescending(a => a.DateCreated);
            return View("ViewOfOrderHistory", userOrders);
        }

        public ActionResult ShippedViewOfOrderHistory()
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Order> userOrders;
            userOrders = db.Orders.Where(p => p.UserId == userId).Where(a => a.State == State.Shipped).Include("OrderItems").OrderByDescending(a => a.DateCreated);
            return View("ViewOfOrderHistory", userOrders);
        }

        public ActionResult CanceledViewOfOrderHistory()
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Order> userOrders;
            userOrders = db.Orders.Where(p => p.UserId == userId).Where(a => a.State == State.Canceled).Include("OrderItems").OrderByDescending(a => a.DateCreated);
            return View("ViewOfOrderHistory", userOrders);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminNewViewOfOrder()
        {
            //bool isAdmin = User.IsInRole("Admin");

            IEnumerable<Order> userOrders;
            userOrders = db.Orders.Include("OrderItems").Where(a => a.State == State.New).OrderBy(a => a.DateCreated).Take(100);
            return View(userOrders);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AdminCanceledViewOfOrder()
        {
            //bool isAdmin = User.IsInRole("Admin");

            IEnumerable<Order> userOrders;
            userOrders = db.Orders.Include("OrderItems").Where(a => a.State == State.Canceled).OrderByDescending(a => a.DateCreated).Take(10);
            return View("AdminNewViewOfOrder", userOrders);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AdminShippedViewOfOrder()
        {
            //bool isAdmin = User.IsInRole("Admin");

            IEnumerable<Order> userOrders;
            userOrders = db.Orders.Include("OrderItems").Where(a => a.State == State.Shipped).OrderByDescending(a => a.DateCreated).Take(10);
            return View("AdminNewViewOfOrder", userOrders);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminAllViewOfOrder()
        {
            //bool isAdmin = User.IsInRole("Admin");

            IEnumerable<Order> userOrders;
            userOrders = db.Orders.Include("OrderItems").OrderByDescending(a => a.DateCreated).Take(100);
            return View("AdminNewViewOfOrder", userOrders);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DisabledProduct()
        {
            List<Product> ProductList;
            var List = db.Products;
          
            
            ProductList = List.Where(a => a.Active == false).ToList();
            
          
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

            return View(ProductList);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult UpdateOrAddProduct(int? productId, bool? responseSuccess, bool? responseError)
        {
            Product searchData;
            EditAddProductViewModel data = new EditAddProductViewModel();
            if (productId.HasValue)
            {
                data.EditModeWithID = true;
                searchData = db.Products.Find(productId);
            }
            else
            {
                data.EditModeWithID = false;
                searchData = new Product();
            }


            data.Categories = db.Categories.ToList();
            data.Product = searchData;
            data.ResponseSuccess = responseSuccess;
            data.ResponseError = responseError;
            return View(data);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UpdateOrAddProduct(EditAddProductViewModel data, HttpPostedFileBase file)
        {
            if (data.Product.ProductID == 0)
            {
                if (file != null && file.ContentLength > 0)
                {
                    if (ModelState.IsValid)
                    {
                        // Generate filename



                        var fileExt = Path.GetExtension(file.FileName);
                        var filename = Guid.NewGuid() + fileExt;

                        var path = Path.Combine(Server.MapPath("~/Content/Products/"), filename);
                        file.SaveAs(path);

                        // Save to DB
                        data.Product.FileNamePhoto = filename;
                        data.Product.AddDate = DateTime.Now;

                        db.Entry(data.Product).State = EntityState.Added;
                        db.SaveChanges();

                        return RedirectToAction("UpdateOrAddProduct", new { responseSuccess = true });
                    }
                    else
                    {
                        var category = db.Categories.ToArray();
                        data.Categories = category;
                        return View(data);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Nie wskazano pliku.");
                    var category = db.Categories.ToArray();
                    data.Categories = category;
                    return View(data);
                }
            }
            else
            {
                if (data.Product.Price == 0 || data.Product.Weight == 0)
                {
                    return RedirectToAction("UpdateOrAddProduct", new { responseError = true });
                }
                else
                {
                    db.Entry(data.Product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("UpdateOrAddProduct", new { responseSuccess = true });
                }

            }



        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public State ChangeOrderState(Order order)
        {
            Order orderToModify = db.Orders.Find(order.OrderID);
            orderToModify.State = order.State;

            if (orderToModify.State == State.Shipped)
            {
                orderToModify.DateShipped = DateTime.Now;
                mailService.SendOrderShippedEmail(orderToModify);
            }
            else if (orderToModify.State == State.Canceled)
            {
                mailService.SendOrderCanceledEmail(orderToModify);
            }
            db.SaveChanges();
            return order.State;
        }

        [AllowAnonymous]
        public ActionResult SendConfirmationEmail(int orderID, string surname)
        {
            var order = db.Orders.Include("OrderItems").SingleOrDefault(a => a.OrderID == orderID && a.Surname == surname);

            if (order == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = order.Email;
            email.Cost = order.SummaryPrice;
            email.Address = string.Format("{0}  {1} {2}, {3}, {4}", order.Country, order.City, order.CityCode, order.Street, order.ApartmentNumber);
            email.Send();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        [AllowAnonymous]
        public ActionResult SendOrderShippedEmail(int orderID, string surname)
        {
            var order = db.Orders.Include("OrderItems").SingleOrDefault(a => a.OrderID == orderID && a.Surname == surname);

            if (order == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            OrderSendedEmail email = new OrderSendedEmail();
            email.To = order.Email;
            email.Cost = order.SummaryPrice;
            email.Address = string.Format("{0}  {1} {2}, {3}, {4}", order.Country, order.City, order.CityCode, order.Street, order.ApartmentNumber);
            email.Send();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        [AllowAnonymous]
        public ActionResult SendOrderCanceledEmail(int orderID, string surname)
        {
            var order = db.Orders.Include("OrderItems").SingleOrDefault(a => a.OrderID == orderID && a.Surname == surname);

            if (order == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            OrderCanceledEmail email = new OrderCanceledEmail();
            email.To = order.Email;
            email.Send();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}