using System.Data.Entity.ModelConfiguration;
using EventsManagementWeb.Core.Models;
namespace EventsManagementWeb.Persistence.EntityConfigurations
{
    public class FollowConfiguration : EntityTypeConfiguration<Following>
    {
        public FollowConfiguration()
        {
            HasKey(f => new {f.FolloweeID, f.FollowerID }); 
        }
    }
}