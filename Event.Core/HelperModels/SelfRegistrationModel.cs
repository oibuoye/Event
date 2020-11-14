using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Event.Core.HelperModels
{
    public class SelfRegistrationModel
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public int StateId { get; set; }

        public string Occupation { get; set; }

        public string CompanyName { get; set; }

        [Required]
        public string DateofBirth { get; set; }

        [DataType(DataType.Password), Required]
        public string Password { get; set; }

    }
}
