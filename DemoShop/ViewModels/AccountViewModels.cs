using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoShop.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Musisz wprowadzić adres e-mail")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Podano niepoprawny adres e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Musisz wprowadzić adres e-mail")]
        [EmailAddress(ErrorMessage = "Podano niepoprawny adres e-mail")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Hasło musi zawierać minimum {2} znaków oraz maksymalnie {1}", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Wprowadzone hasła nie sa takie same")]
        public string ConfirmPassword { get; set; }
    }


}