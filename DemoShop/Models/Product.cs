using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoShop.Models
{
    public class Product
    {

        public int ProductID { get; set; }
        
        //field with virtual class - key 
        public int CategoryID { get; set; }

        [Display(Name ="Tytuł")]
        [Required]
        public string ProductTitle { get; set; }

        [Display(Name = "Producent")]
        [Required]
        public string Manufacturer { get; set; }

        [Display(Name ="Data dodania")]
        public DateTime AddDate { get; set; }

        [Display(Name ="Opis produktu")]
        [Required]
        public string  Description { get; set; }

        [Display(Name ="Cena")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Waga")]
        [Required]
        public decimal Weight { get; set; }

        [Display(Name ="Promocja")]
        public bool Promotion { get; set; }

        [Display(Name ="Najlepszy produkt")]
        public bool TheBestProduct { get; set; }

        [Display(Name ="Aktywny")]
        public bool Active { get; set; }


        public string FileNamePhoto { get; set; }

        public virtual Category Category { get; set; }
    }
}