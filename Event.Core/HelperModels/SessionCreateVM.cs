using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Event.Core.HelperModels
{
    public class SessionCreateVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Presenter { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string Abstract { get; set; }

        public List<string> Voters { get; set; }

        public Int64 EventId { get; set; }
    }
}
