using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueBuzz.Models
{
    public class EventGenres
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public string VolumeLevel { get; set; }

        public virtual ICollection<Events> Events { get; set; }
    }
}