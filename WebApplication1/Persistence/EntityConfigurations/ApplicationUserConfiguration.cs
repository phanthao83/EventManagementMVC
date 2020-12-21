using System.Data.Entity.ModelConfiguration;
using EventsManagementWeb.Core.Models;
namespace EventsManagementWeb.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(u => u.FullName).IsRequired().HasMaxLength(100);
            HasMany(u => u.Followees).WithRequired(u => u.Follower).WillCascadeOnDelete(false);
            HasMany(u => u.Followers).WithRequired(u => u.Followee).WillCascadeOnDelete(false); 
            
        }
    }
}