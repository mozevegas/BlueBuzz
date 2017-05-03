using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueBuzz.Models
{
    public class Venues
    {
        public int Id { get; set; }
        public string Venue { get; set; }
        public string VenAddress { get; set; }

        public virtual ICollection<Events> Events { get; set; } // = new HashSet<Events>  // where does this come from? creating a generic container.

    }
}