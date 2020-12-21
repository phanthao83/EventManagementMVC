using System.Collections.Generic;
using EventsManagementWeb.Core.Dtos ;
using EventsManagementWeb.Core.Models;

namespace EventsManagementWeb.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<UserNotification> GetUnReadNotification(string userID);
        IEnumerable<Notification> GetUnReadNotificationWithArtistAndGener(string userID);
        IEnumerable<NotificationDto> GetUnreadNotificationDto(string userID); 
    }
}
