using DemoShop.DAL;
using DemoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.Infrastructure
{
    public class ShoppingCartManager
    {
        private DemoShopContext db;
        private InterfaceSessionManager Session;

        public const string CartSessionKey = "CartData";

        public ShoppingCartManager(InterfaceSessionManager Session, DemoShopContext db)
        {
            this.db = db;
            this.Session = Session;
        }

        public void AddToShoppingCart(int productID)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(c => c.Product.ProductID == productID);

            if (cartItem != null)
            {
                cartItem.Quantity++;
                cartItem.WeightProducts = (cartItem.WeightProducts + cart.Where(a => a.Product.ProductID == productID).Select(i => i.WeightProducts).Single());
            }
            else
            {
                var AddProduct = db.Products.Where(a => a.ProductID == productID).SingleOrDefault();
                if (AddProduct != null)
                {
                    var newcartData = new CartData()
                    {
                        Product = AddProduct,
                        Quantity = 1,
                        TotalPriceProducts = AddProduct.Price,
                        WeightProducts = AddProduct.Weight
                    };
                    cart.Add(newcartData);
                }
            }
            Session.Set(CartSessionKey, cart);
        }

        public List<CartData> GetCart()
        {
            List<CartData> cart;
            if (Session.Get<List<CartData>>(CartSessionKey) == null)
            {
                cart = new List<CartData>();
            }
            else
            {
                cart = Session.Get<List<CartData>>(CartSessionKey) as List<CartData>;
            }
            return cart;
        }

        public int RemoveFromCart(int productID)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(a => a.Product.ProductID == productID);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    cartItem.WeightProducts -= cart.Where(a => a.Product.ProductID == productID).Select(i => i.WeightProducts).Single();
                    return cartItem.Quantity;
                }
                else
                {
                    cart.Remove(cartItem);
                }
            }
            return 0;
        }

        public decimal GetCartTotalWeight()
        {
            var cart = this.GetCart();
            return cart.Sum(a => (a.WeightProducts));
        }

        public decimal GetCartTotalPrice()
        {
            var cart = this.GetCart();
            return cart.Sum(a => (a.Product.Price * a.Quantity));
        }

        public int GetCartItemsCount()
        {
            var cart = this.GetCart();
            int count = cart.Sum(a => a.Quantity);

            return count;
        }


        public Order CreateOrder(Order newOrder, string userId)
        {
            var cart = this.GetCart();

            newOrder.DateCreated = DateTime.Now;
            newOrder.UserId = userId;

            this.db.Orders.Add(newOrder);

            if (newOrder.OrderItems == null)
            {
                newOrder.OrderItems = new List<OrderItem>();
            }

            decimal cartTotalPrice = 0;
            decimal cartTotalWeight = 0;

            foreach (var cartItem in cart)
            {
                var newOrderItem = new OrderItem()
                {
                    ProductID = cartItem.Product.ProductID,
                    Quantity = cartItem.Quantity,
                    SinglePrice = cartItem.Product.Price
                };
                cartTotalPrice += (cartItem.Quantity * cartItem.Product.Price);
                cartTotalWeight += (cartItem.Quantity * cartItem.Product.Weight);

                newOrder.OrderItems.Add(newOrderItem);
            }

            newOrder.SummaryPrice = cartTotalPrice;
            newOrder.SummaWeight = cartTotalWeight;

            this.db.SaveChanges();

            return newOrder;
        }

        public void ClearCart()
        {
            Session.Set<List<CartData>>(CartSessionKey, null);
        }
     
    }
}