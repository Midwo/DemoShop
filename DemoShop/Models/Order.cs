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

        [Required(ErrorMessage ="Wprowadź imię")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwisko")]
        [StringLength(40)]
        public string Surname { get; set; }

        [Required(ErrorMessage ="Musisz wybrać kraj")]
        public Country Country { get; set; }

        [Required(ErrorMessage ="Wprowadź miasto")]
        [StringLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage ="Wprowadź kod pocztowy")]
        [StringLength(10)]
        public string CityCode { get; set; }

        [Required(ErrorMessage ="Wprowadź nazwę ulicy")]
        [StringLength(60)]
        public string Street { get; set; }

        [Required(ErrorMessage ="Wprowadź numer mieszkania")]
        [StringLength(25)]
        public string ApartmentNumber {get; set;}

        [Required(ErrorMessage = "Musisz wprowadzić numer telefonu")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "Długość numeru musi być z zakresu 9-15 znaków")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Musisz wprowadzić adres e-mail")]
        [EmailAddress(ErrorMessage ="Błedny adres e-mail")]
        public string Email { get; set; }

        public string Comment { get; set; }

        public decimal SummaryPrice { get; set; }

        public decimal SummaWeight { get; set; }

        public State State { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }

    public enum Country
    {
        [Display(Name ="Polska")]
        Poland,
        [Display(Name ="Niemcy")]
        Germany,
        [Display(Name ="Anglia")]
        England,
        [Display(Name = "Rosja")]
        Russia
    }

    public enum State
    {
        [Display(Name ="Nowe")]
        New,
        [Display(Name ="Anulowane")]
        Canceled,
        [Display(Name ="Reklamacja/Skarga")]
        Complained,
        [Display(Name ="Wysłane")]
        Shipped
    }
}