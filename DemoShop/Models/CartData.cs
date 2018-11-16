using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.Models
{
    public class CartData
    {
        public Product Product { get; set; }
        public int  Quantity { get; set; }
        public decimal TotalPriceProducts { get; set; }
        public decimal WeightProducts { get; set; }
    }
}