using DemoShop.DAL;
using DemoShop.Infrastructure;
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
            return View();
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
    }
}