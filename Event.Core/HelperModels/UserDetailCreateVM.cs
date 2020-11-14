using Event.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Core.HelperModels
{
    public class UserDetailCreateVM
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Int64 TestPartyId { get; set; }

        public UserTypeEnum UserType { get; set; }
    }
}
