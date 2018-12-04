using DemoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.ViewModels
{
    public class EditAddProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public bool EditModeWithID { get; set; }
        public bool? ResponseSuccess { get; set; }
        public bool? ResponseError { get; set; }
    }
}