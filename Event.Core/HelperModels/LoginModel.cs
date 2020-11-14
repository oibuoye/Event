using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Event.Core.HelperModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email field is required"), MaxLength(50), EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Password field is required")]
        public string Password { get; set; }

    }
}
