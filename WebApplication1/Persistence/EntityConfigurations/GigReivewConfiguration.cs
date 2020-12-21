using System.Data.Entity.ModelConfiguration;
using EventsManagementWeb.Core.Models;

namespace EventsManagementWeb.Persistence.EntityConfigurations
{ 
    public class GigReivewConfiguration : EntityTypeConfiguration<GigReviews>
    {
        public GigReivewConfiguration()
        {
            HasKey(u => new { u.GigId, u.UserId });
            Property(u => u.Comment).IsRequired().HasMaxLength(200);
            //      HasRequired(u => u.User).WithMany(u => u.UserNotification).WillCascadeOnDelete(false);
            //     HasRequired (u=> u.User).WithMany (u => u.GigReview )
            HasRequired(u => u.Gig).WithMany(u => u.GigReview).WillCascadeOnDelete(false); 
        }
    }
}