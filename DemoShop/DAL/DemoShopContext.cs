using DemoShop.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoShop.DAL
{
    public class DemoShopContext : IdentityDbContext<ApplicationUser>
    {

        public DemoShopContext() : base("DemoShopContext")
        {
         
        }

        static DemoShopContext()
        {
            Database.SetInitializer<DemoShopContext>(new DemoShopInitializer());
        }

        public static DemoShopContext Create()
        {
            return new DemoShopContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> GetOrders { get; set; }
    }
}