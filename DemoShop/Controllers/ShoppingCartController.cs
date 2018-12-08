using DemoShop.App_Start;
using DemoShop.DAL;
using DemoShop.Infrastructure;
using DemoShop.Models;
using DemoShop.ViewModels;
using Hangfire;
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
    public class ShoppingCartController : Controller
    {
        private ShoppingCartManager shoppingCartManager;
        private InterfaceSessionManager interfaceSessionManager;
        private DemoShopContext db = new DemoShopContext();
        private IMailService mailService;
        // GET: ShoppingCard

        public ShoppingCartController(IMailService mailService)
        {
            this.interfaceSessionManager = new SessionManager();
            this.shoppingCartManager = new ShoppingCartManager(this.interfaceSessionManager, this.db);

        }
         
        public ActionResult Index()
        {
            var cartDatas = shoppingCartManager.GetCart();
            var totalPrice = shoppingCartManager.GetCartTotalPrice();

            CartViewModel cartViewModel = new CartViewModel() { CartDatas = cartDatas, TotalPrice = totalPrice };

            return View(cartViewModel);
        }


        public ActionResult AddToShoppingCart(int id)
        {
            shoppingCartManager.AddToShoppingCart(id);
            return RedirectToAction("Index");
        }

        public int GetCartItemsCount()
        {
            return shoppingCartManager.GetCartItemsCount();
        }


        public ActionResult RemoveFromCart(int ProductID)
        {
            int itemCount = shoppingCartManager.RemoveFromCart(ProductID);
            int actualItemsCount = shoppingCartManager.GetCartItemsCount();
            decimal totalCost = shoppingCartManager.GetCartTotalPrice();

            var result = new CartRemoveViewModel
            {
                ActualItemsCount = actualItemsCount,
                TotalCost = totalCost,
                RemoveItemId = ProductID,
                RemovedItemCount = itemCount
            };

            return Json(result);
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
        //get
        public async Task<ActionResult> PaidCart()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order
                {
                    Name = user.UserInformation.Name,
                    ApartmentNumber = user.UserInformation.ApartmentNumber,
                    City = user.UserInformation.City,
                    CityCode = user.UserInformation.CityCode,
                    Country = user.UserInformation.Country,
                    Email = user.UserInformation.Email,
                    Phone = user.UserInformation.Phone,
                    Street = user.UserInformation.Street,
                    Surname = user.UserInformation.Surname
                };
                return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("PaidCart", "ShoppingCart")});
            }
        }
       // post
        [HttpPost]
        public async Task<ActionResult> PaidCart(Order orderInformation)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var newOrder = shoppingCartManager.CreateOrder(orderInformation, userId);

                var user = await UserManager.FindByIdAsync(userId);

                TryUpdateModel(user.UserInformation);

                await UserManager.UpdateAsync(user);

                shoppingCartManager.ClearCart();

                //var order = db.Orders.Include("OrderItems").Include("OrderItems.Product").SingleOrDefault(a => a.OrderID == newOrder.OrderID);
                var order = db.Orders.Include("OrderItems").SingleOrDefault(a => a.OrderID == newOrder.OrderID);

                string url = Url.Action("SendConfirmationEmail", "Manage", new { orderID = newOrder.OrderID, surname = newOrder.Surname }, Request.Url.Scheme);

                //BackgroundJob.Enqueue(() => Helpers.CallUrl(url));
                mailService.SendOrderConfirmationEmail(order);

                return RedirectToAction("OrderConfirmation");

            }
            else
            {
                return View(orderInformation);
            }
        

        }


        public ActionResult OrderConfirmation()
        {
            return View();
        }


    }
}