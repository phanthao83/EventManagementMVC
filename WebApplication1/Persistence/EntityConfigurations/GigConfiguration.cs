using System.Data.Entity.ModelConfiguration;
using EventsManagementWeb.Core.Models;

namespace EventsManagementWeb.Persistence.EntityConfigurations
{
    public class GigConfiguration : EntityTypeConfiguration<Gig>
    {
        public GigConfiguration()
        {
            Property(g => g.ArtistID).IsRequired();
            Property(g => g.Venue).IsRequired().HasMaxLength(255);
            Property(g => g.GenreID).IsRequired(); 

            //Foregin Key 
            HasMany(g => g.Attendances).WithRequired(g => g.Gig).WillCascadeOnDelete(false); 
        }
    }
}