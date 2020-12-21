using System;
using EventsManagementWeb.Core.Models; 

namespace  EventsManagementWeb.Core.Dtos
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public NotificationType Type { get;  set; }
        public DateTime DateTime { get;  set; }
        public string OrginalVenue { get;  set; }
        public DateTime OrginalDateTime { get;  set; }
        public GenreDto OrginalGenre { get; set; }
        public GigDto Gig { get;  set; }
    }
}