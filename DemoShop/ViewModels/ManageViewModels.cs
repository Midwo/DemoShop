using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoShop.ViewModels
{
   public class OtherLogInViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
        public bool ShowRemoveButton { get; set; }
        public SetPasswordViewModel SetPasswordViewModel { get; set; }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        public bool HasPassword { get; set; }
        public bool isAdmin { get; set; }
        public bool isUserClient { get; set; }
    }


    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Hasłu musi mieć minimum {0} znaków oraz maksymalnie {2} ", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło:")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz nowe hasło:")]
        [Compare("NewPassword", ErrorMessage = "Hasła nie są takie same")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Stare hasło:")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Hasłu musi mieć minimum {0} znaków oraz maksymalnie {2} ", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło:")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz nowe hasło:")]
        [Compare("NewPassword", ErrorMessage = "Hasła nie są takie same")]
        public string ConfirmPassword { get; set; }
    }

}