using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoShop.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [Display(Name = "Imię")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Należy wprowadzić imię")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Należy wprowadzić email")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Należy wprowadzić numer telefonu")]
        [StringLength(1000, MinimumLength = 9, ErrorMessage = "Minimum 9 znaków na numer")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "Zły format numeru")]
        public string Phone { get; set; }

        [Display(Name = "Wiadomość")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Należy wprowadzić treść wiadomości")]
        public string Message { get; set; }

        [Display(Name = "Odpowiedziano")]
        public bool SentAnswer { get; set; }
    }
}