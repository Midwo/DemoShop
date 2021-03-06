﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoShop.Models
{
    public class Newsletter
    {
        [Key]
        public int NewsletterID { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Należy wprowadzić email")]
        public string Email { get; set; }

        public string UnscribeCode { get; set; }

        public string UnscribeLink { get; set; }
    }
}