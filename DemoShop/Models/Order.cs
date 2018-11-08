using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoShop.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateShipped { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string Street { get; set; }
        public string ApartmentNumber {get; set;}
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public decimal SummaryPrice { get; set; }

    }

    public enum Country
    {
        [Display(Name ="Polska")]
        Poland,
        [Display(Name ="Niemcy")]
        Deutchland


    }
}