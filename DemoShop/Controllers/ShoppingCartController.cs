using DemoShop.DAL;
using DemoShop.Infrastructure;
using DemoShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ShoppingCartManager shoppingCartManager;
        private InterfaceSessionManager interfaceSessionManager;
        private DemoShopContext db = new DemoShopContext();

        // GET: ShoppingCard

        public ShoppingCartController()
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
    }
}