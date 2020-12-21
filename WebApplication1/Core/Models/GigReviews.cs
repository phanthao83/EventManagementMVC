
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsManagementWeb.Core.Models
{
    public class GigReviews
    {

         public int GigId { get; private set; }
        public string UserId { get; private set; }

        public Gig Gig { get; private set; }
        public ApplicationUser User { get; private set; }

        public string Comment { get; set; }

        public GigReviews(int gigID, string userId, string comment) {
            this.GigId = gigID;
            this.UserId = userId;
            this.Comment = comment; 
        }
        public GigReviews() {
        }
    }
}