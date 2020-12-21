
using EventsManagementWeb.Core.Repositories;
using EventsManagementWeb.Core.Models;
namespace EventsManagementWeb.Persistence.Repositories
{
   
    public class UnitOfWork : IUnitOfWork
    {
        public IAttandanceRepository Attendance { get; private set;  }
        public IFollowRepository Follow { get; private set; }
        public IGenerRepository Gener {get; private set; }
        public IGigRepository Gig { get; private set; }
        public INotificationRepository Notification { get; private set; }
        public IGigReviewRepository GigReviews { get; private set; }


        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gig = new GigRepository(_context);
            Attendance = new AttandanceRepository(_context);
            Follow = new FollowRepository(_context);
            Gener = new GenerRepository(_context);
            Notification = new NotificationRepository(_context);
            GigReviews = new GigReviewsRepository(_context); 

        }

        public void Finish()
        {
            _context.SaveChanges();
        }


    }
   
}