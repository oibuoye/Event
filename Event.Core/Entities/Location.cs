using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Event.Core.Enums;
using Newtonsoft.Json;

namespace Event.Core.Entities
{
    public class Location
    {
        [JsonProperty(PropertyName = "address")]
        [MaxLength(200)]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "city")]
        [MaxLength(100)]
        public string City { get; set; }

        [JsonProperty(PropertyName = "country")]
        [MaxLength(50)]
        public string Country { get; set; }
    }
}
