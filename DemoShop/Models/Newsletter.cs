using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoShop.Models
{
    public class Newsletter
    {
        [Display(Name = "Email")]
        [EmailAddress]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Należy wprowadzić email")]
        public string Email { get; set; }

        public string UniscribeCode { get; set; }
    }
}