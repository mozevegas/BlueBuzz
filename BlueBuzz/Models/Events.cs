using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlueBuzz.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }


        public int? VenueId { get; set; }
        [ForeignKey("VenueId")]
        public Venues Venue { get; set; }

        public int? GenreId { get; set; }
        [ForeignKey("GenreId")]
        public EventGenres Genre { get; set; }
    }
}