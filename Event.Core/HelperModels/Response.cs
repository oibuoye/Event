using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Core.HelperModels
{
    public class Response
    {
        public IEnumerable<ConferenceEventVM> events { get; set; }

    }
}
