using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using EventsManagementWeb.Core.Models;
namespace EventsManagementWeb.Persistence.EntityConfigurations
{
    public class UserNotificationConfiguration : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration()
        {
            HasKey(u => new { u.UserID, u.NotificationID });
            HasRequired(u => u.User).WithMany(u => u.UserNotification).WillCascadeOnDelete(false); 
        }
    }
}