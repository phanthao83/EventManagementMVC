using System.Data.Entity.ModelConfiguration;
using EventsManagementWeb.Core.Models;
namespace EventsManagementWeb.Persistence.EntityConfigurations
{
    public class GenerConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenerConfiguration()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(255); 
        }
    }
}