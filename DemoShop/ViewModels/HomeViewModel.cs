using DemoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.ViewModels
{
    public class HomeViewModel
    {

        public IEnumerable<Product> Promotions { get; set; }
        public IEnumerable<Product> TheBestProducts { get; set; }
        public IEnumerable<Product> NewProducts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Newsletter Newsletter { get; set; }
    }
}