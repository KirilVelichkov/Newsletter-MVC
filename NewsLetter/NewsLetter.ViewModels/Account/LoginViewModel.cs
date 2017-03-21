using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "* Please enter a valid email")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password, ErrorMessage = "Please enter a password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

}
