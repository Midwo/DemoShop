using DemoShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoShop.DAL
{
    public class DemoShopContext : DbContext
    {

        public DemoShopContext() : base("DemoShopContext")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> GetOrders { get; set; }
    }
}