using System.Collections.Generic;
using System.Linq;
using EventsManagementWeb.Core.Models; 

namespace EventsManagementWeb.Core.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> UpcomingGig { get; set;  }
        public bool IsAuthenticated { get; set; }
        public string Heading { get; set; }

        public string SearchTerm {get; set;}

       
        public ILookup<int, Attendance> Attendances { get; set; }
        public ILookup<string, Following> Following {get; set; }
    }
}