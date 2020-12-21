using System;

namespace EventsManagementWeb.Core.Models
{
    public class Notification
    {
        public int ID {get; private set;}

        public NotificationType Type { get; private set; }
        public DateTime DateTime { get; private set; }
        public string OrginalVenue { get;  private set; }
        public DateTime OrginalDateTime { get; private set;  }
        public Genre OrginalGener {get; private set;}
        public Gig Gig {get;  private set; }

        protected Notification() 
        { 
        }
        private Notification(Gig gigInfo, NotificationType ntype)
        {
            if (gigInfo == null)
                throw new System.ArgumentNullException("Notification.Gig"); 
            DateTime = DateTime.Now;
            OrginalDateTime = gigInfo.DateTime;  
            Gig = gigInfo;
            Type = ntype; 
        }

        public static Notification CancelGig(Gig gigInfo)
        {
            return new Notification(gigInfo, NotificationType.GigCanceled);

        }        
        public static Notification CreateGig(Gig gigInfo )
        {
            return new Notification(gigInfo ,NotificationType.GigNew ); 
        
        }

        public static Notification UpdateGig(Gig newGig, DateTime orgDate, string orgVenue, Genre oldGenre)
        {
            Notification notification = new Notification(newGig, NotificationType.GigUpdated);
            notification.OrginalDateTime = orgDate;
            notification.OrginalVenue = orgVenue;
            notification.OrginalGener = oldGenre; 

            return notification; 

        }

    }
}