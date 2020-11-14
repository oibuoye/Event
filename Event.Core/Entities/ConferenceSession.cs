using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Event.Core.Enums;

namespace Event.Core.Entities
{
    [Table("ConferenceSession")]
    public class ConferenceSession
    {
        public Int64 Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Presenter { get; set; }

        public int Duration { get; set; }

        [MaxLength(100)]
        public string Level { get; set; }

        [MaxLength(300)]
        public string Abstract { get; set; }

        public List<string> Voters { get; set; }

        public Int64 EventId { get; set; }
    }
}
