using Newtonsoft.Json;
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
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [MaxLength(200)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "imageurl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "onlineurl")]
        public string OnlineUrl { get; set; }

        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }
    }
}
