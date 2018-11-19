using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.ViewModels
{
    public class CartRemoveViewModel
    {
        public decimal TotalCost { get; set; }
        public int ActualItemsCount { get; set; }
        public int RemovedItemCount { get; set; }
        public int RemoveItemId { get; set; }
    }
}