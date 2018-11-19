using DemoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.ViewModels
{
    public class CartViewModel
    {
        public List<CartData> CartDatas { get; set; }

        public decimal TotalPrice { get; set; }
    }
}