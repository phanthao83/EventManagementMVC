using EventsManagementWeb.Core.Models;
using EventsManagementWeb.Persistence.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
namespace EventsManagementWeb.Persistence
{
    public class ApplicationDbContext:  IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Following { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<UserNotification> UserNotification { get; set; }
        public DbSet<GigReviews> GigReviews { get; set; }

        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new AttendanceConfiguration());
            modelBuilder.Configurations.Add(new FollowConfiguration());
            modelBuilder.Configurations.Add(new GenerConfiguration());
            modelBuilder.Configurations.Add(new GigConfiguration());
            modelBuilder.Configurations.Add(new NotificationConfiguration());
            modelBuilder.Configurations.Add(new UserNotificationConfiguration());
            modelBuilder.Configurations.Add(new GigReivewConfiguration());


            base.OnModelCreating(modelBuilder);
        }

    }
}
