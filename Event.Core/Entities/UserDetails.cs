using Event.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Core.Entities
{
    [Table("UserDetails")]
    public class UserDetails : BaseModel
    {
        public long Id { get; set; }

        [MaxLength(200)]
        public string Firstname { get; set; }

        [MaxLength(200)]
        public string Lastname { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string ApplicationUserId { get; set; }

        public bool IsActive { get; set; }

    }
}
