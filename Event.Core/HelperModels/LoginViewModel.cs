using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Core.HelperModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email field is required"), MaxLength(50), EmailAddress]
        public string UserName { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Password field is required")]
        public string PassWord { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }

    }
}
