using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoShop.Models
{
    public class UserInformation
    {
        [Display(Name = "Imię:")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko:")]
        public string Surname { get; set; }

        [Display(Name = "Kraj:")]
        public Country Country { get; set; }

        [Display(Name = "Miasto:")]
        public string City { get; set; }

        [Display(Name = "Kod pocztowy:")]
        public string CityCode { get; set; }

        [Display(Name = "Ulica:")]
        public string Street { get; set; }

        [Display(Name = "Numer domu:")]
        public string ApartmentNumber { get; set; }

        [Display(Name = "Nr. kontaktowy:")]
        public string Phone { get; set; }

        [Display(Name = "Adres E-mail:")]
        [EmailAddress(ErrorMessage = "Błedny adres e-mail")]
        public string Email { get; set; }

    }
}