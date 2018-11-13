using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoShop.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Display(Name = "Tytuł")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        public string FileNamePhoto { get; set; }

        [Display(Name = "Aktywny")]
        public bool Active { get; set; }

        [Display(Name = "Ważna kategoria")]
        public bool Favoritism { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}