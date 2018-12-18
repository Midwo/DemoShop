using DemoShop.App_Start;
using DemoShop.DAL;
using DemoShop.Infrastructure;
using DemoShop.Models;
using DemoShop.ViewModels;
using Hangfire;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        private InterfaceSessionManager sessionManager;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET: ShoppingCard

        public ShoppingCartController(IMailService mailService, InterfaceSessionManager sessionManager)
        //public ShoppingCartController()
        {
            this.sessionManager = sessionManager;
            this.mailService = mailService;
            //this.sessionManager = new SessionManager();
            //this.mailService = new HangFirePostalIMailService();

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
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("PaidCart", "ShoppingCart") });
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

                // string url = Url.Action("SendConfirmationEmail", "Manage", new { orderID = newOrder.OrderID, surname = newOrder.Surname }, Request.Url.Scheme);

                ///BackgroundJob.Enqueue(() => Helpers.CallUrl(url));
                this.mailService.SendOrderConfirmationEmail(order);

                return RedirectToAction("PaymentPage", order);

            }
            else
            {
                return View(orderInformation);
            }


        }
        public ActionResult PaymentPage(Order order)
        {
            string inputText = "asdasd" + order.SummaryPrice.ToString().Replace(",", ".") + order.OrderID + "adsds2q344234234234";
            ViewBag.SumMD5 = CreateMD5(inputText);
            return View(order);
        }

        public ActionResult PaymentPageID(int orderID)
        {

            var order = db.Orders.SingleOrDefault(a => a.OrderID == orderID);

            return RedirectToAction("PaymentPage", "ShoppingCart", order);
        }

        public ActionResult OrderConfirmation()
        {

            return View();
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public ActionResult PaymentSuccess()
        {
            return View();
        }
        public ActionResult PaymentError()
        {
            return View();
        }
        public ActionResult Report()
        {
            string id = Request.Form["id"];
            string trId = Request.Form["tr_id"];
            string trDate = Request.Form["tr_date"];
            string trCRC = Request.Form["tr_crc"];
            string trAmount = Request.Form["tr_amount"];
            string trPaid = Request.Form["tr_paid"];
            string trDesc = Request.Form["tr_desc"];
            string trStatus = Request.Form["tr_status"];
            string trError = Request.Form["tr_error"];
            string trEmail = Request.Form["tr_email"];
            string md5Sum = Request.Form["md5sum"];

            if (!ContainsNullOrEmptyString(id, trId, trDate, trAmount, trCRC))
            {
                Response.Write("TRUE");



                bool isSuccessful = IsValid(md5Sum, trId, trAmount, trCRC);

                if (isSuccessful == true)
                {
                    logger.Info("Wykonano prawidłowo płatność");
                    int OrderID = Int32.Parse(trCRC);
                    Order order = db.Orders.SingleOrDefault(a => a.OrderID == OrderID);
                    this.mailService.SendCompletedOrderEmail(order);

                    order.PaymentState = true;   
   
                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();


                }
                else
                {
                    logger.Info("Nie wykonano prawidłowo płatności");
                }
            }

            return View();
        }
        private bool ContainsNullOrEmptyString(params string[] strings)
        {
            var IsEmpty = false;
            foreach (var item in strings.ToList())
            {
                IsEmpty = String.IsNullOrEmpty(item) ? true : IsEmpty;
            }

            return IsEmpty;
        }
        public bool IsValid(string md5Sum, string id, string amount, string crc)
        {
            string inputText = "asdasd" + id + amount.ToString().Replace(",", ".") + crc + "adsds2q344234234234";
            string Md5String = CreateMD5(inputText);

            if (md5Sum.ToLower() == Md5String.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}