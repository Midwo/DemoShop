using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoShop.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateShipped { get; set; }

        [Display(Name = "Imię:")]
        [Required(ErrorMessage = "Wprowadź imię")]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Nazwisko:")]
        [Required(ErrorMessage = "Wprowadź nazwisko")]
        [StringLength(40)]
        public string Surname { get; set; }

        [Display(Name = "Kraj:")]
        [Required(ErrorMessage = "Musisz wybrać kraj")]
        public Country Country { get; set; }

        [Display(Name = "Miasto:")]
        [Required(ErrorMessage = "Wprowadź miasto")]
        [StringLength(30)]
        public string City { get; set; }

        [Display(Name = "Kod pocztowy:")]
        [Required(ErrorMessage = "Wprowadź kod pocztowy")]
        [StringLength(10)]
        public string CityCode { get; set; }

        [Display(Name = "Ulica:")]
        [Required(ErrorMessage = "Wprowadź nazwę ulicy")]
        [StringLength(60)]
        public string Street { get; set; }

        [Display(Name = "Numer mieszkania:")]
        [Required(ErrorMessage = "Wprowadź numer mieszkania")]
        [StringLength(25)]
        public string ApartmentNumber { get; set; }

        [Display(Name = "Telefon:")]
        [Required(ErrorMessage = "Musisz wprowadzić numer telefonu")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "Długość numeru musi być z zakresu 9-15 znaków")]
        public string Phone { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Musisz wprowadzić adres e-mail")]
        [EmailAddress(ErrorMessage = "Błedny adres e-mail")]
        public string Email { get; set; }

        [Display(Name = "Komentarz/Uwagi:")]
        public string Comment { get; set; }

        [Display(Name = "Łączna cena:")]
        public decimal SummaryPrice { get; set; }

        [Display(Name = "Łączna waga:")]
        public decimal SummaWeight { get; set; }

        [Display(Name = "Status:")]
        public State State { get; set; }

        [Display(Name = "Koszt przesyłki")]
        public decimal ShippingCost { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }


    }

    public enum Country
    {
        [Display(Name = "Polska")]
        Poland,
        [Display(Name = "Niemcy")]
        Germany,
        [Display(Name = "Anglia")]
        England,
        [Display(Name = "Rosja")]
        Russia
    }

    public enum State
    {
        [Display(Name = "Nowe")]
        New,
        [Display(Name = "Anulowane")]
        Canceled,
        [Display(Name = "Wysłane")]
        Shipped
    }
}