using Event.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Core.HelperModels
{
    public class ConferenceEventVM
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string OnlineUrl { get; set; }

        public Location Location { get; set; }
    }
}
