using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoShop.Models
{
    public class UserInformation
    {

        public string Name { get; set; }


        public string Surname { get; set; }


        public Country Country { get; set; }


        public string City { get; set; }

        public string CityCode { get; set; }


        public string Street { get; set; }


        public string ApartmentNumber { get; set; }

        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Błedny adres e-mail")]
        public string Email { get; set; }

    }
}