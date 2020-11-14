using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Core.HelperModels
{
    public class UserDetailsRecordDisplayVM
    {
        public Int64 Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string FacilityName { get; set; }

        public string DateCreated { get; set; }

        public string UserId { get; set; }

        public string UserType { get; set; }
    }

    public class UserDetailsDisplayVM
    {
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public IEnumerable<UserDetailsRecordDisplayVM> Records { get; set; }
    }

}
