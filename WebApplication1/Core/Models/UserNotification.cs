
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EventsManagementWeb.Core.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public string UserID { get; private set; }
        [Key]
        [Column(Order = 2)]
        public int NotificationID { get; private set; }
        public ApplicationUser User { get; private set; }
        public Notification Notification { get; private set; }
        public bool IsRead { get; private set; }
        public string Comment { get; set; }

        public UserNotification()
        {
        }
        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null)
                throw new System.ArgumentNullException("UserNotification.User");
            if (notification == null)
                throw new System.ArgumentNullException("UserNotification.Notification");
            User = user;
            Notification = notification;
        }
        
        public void MarkRead() {
            IsRead = true; 
        }
    }
}