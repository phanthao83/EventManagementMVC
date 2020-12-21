using System.Collections.Generic;
using System.Linq;
using EventsManagementWeb.Core.Models;

namespace WebApplication1.Core.ViewModels
{
    public class GigViewModel
    {
        public bool IsAuthenticated { get; set; }
        public string Heading { get; set; }
        public string InputComment { get; set; }
        public Gig Gig { get; set; }
    }
}