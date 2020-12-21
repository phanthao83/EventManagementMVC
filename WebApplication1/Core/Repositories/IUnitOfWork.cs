
namespace EventsManagementWeb.Core.Repositories
{
    public interface IUnitOfWork
    {
        IAttandanceRepository Attendance { get; }
        IFollowRepository Follow { get; }
        IGenerRepository Gener { get; }
        IGigRepository Gig { get; }
        INotificationRepository Notification { get; }
        IGigReviewRepository GigReviews { get; }

        void Finish(); 
    }
  
}
