using System;

namespace  EventsManagementWeb.Core.Dtos
{
    public class GigDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public string Venue { get; set; }
        public GenreDto  Genre { get; set; }
        public ArtistDto Artist { get; set; }

        public bool IsCancelled { get; set; }

    }
}