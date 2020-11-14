using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Core.Entities
{
    [Table("ConferenceEvent")]
    public class ConferenceEvent
    {
        public Int64 Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string OnlineUrl { get; set; }

        public Location Location { get; set; }
    }
}
