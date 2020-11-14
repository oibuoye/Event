using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Core.Entities
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
