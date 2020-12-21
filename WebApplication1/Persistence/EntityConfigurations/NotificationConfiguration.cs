using System.Data.Entity.ModelConfiguration;
using EventsManagementWeb.Core.Models;
namespace EventsManagementWeb.Persistence.EntityConfigurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasRequired(n => n.Gig); 
        }
    }
}