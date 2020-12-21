using System.Data.Entity;
using EventsManagementWeb.Core.Models; 
namespace EventsManagementWeb.Persistence
{
    interface IApplicationDbContext
    {
        DbSet<Gig> Gigs { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Attendance> Attendances { get; set; }
        DbSet<Following> Following { get; set; }
        DbSet<Notification> Notification { get; set; }
        DbSet<UserNotification> UserNotification { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
        DbSet<GigReviews> GigReviews { get; set; }
    }
}
