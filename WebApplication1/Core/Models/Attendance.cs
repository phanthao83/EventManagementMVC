namespace EventsManagementWeb.Core.Models
{
    public class Attendance
    {
        public Gig Gig { get; set; }
        public ApplicationUser Attendee { get; set; }
        public int GigID { get; set; }
         public string AttendeeID { get; set; } 
    }
}