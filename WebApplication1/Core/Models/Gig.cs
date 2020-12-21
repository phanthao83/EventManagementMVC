using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EventsManagementWeb.Core.ViewModels; 
namespace EventsManagementWeb.Core.Models
{
    public class Gig
    {
        public int ID {get; set; }
       
      
        public DateTime DateTime {get; set; }

        public string Venue { get; set; }
        public Genre Genre { get; set; }


        public byte GenreID { get; set; }
     
        public ApplicationUser Artist { get; set; }
        public string ArtistID { get; set; }

        public bool IsCancelled { get; set; }

        public ICollection<Attendance> Attendances {get; private set; }
      public ICollection<GigReviews> GigReview { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>(); 
        
        }

        public void Create(string artistID, GigsViewFormModel view )
        { 
            ArtistID = artistID ;  
			Venue = view.Venue ; 
			GenreID = view.Gener;
            DateTime = view.GetDateTime(); 
            //Add notification 


        }
        public void Cancel() 
        {
            IsCancelled = true; 
            //Add notification
            AddNotification(NotificationType.GigCanceled, this.DateTime, ""); 
            
        }

        public void Update(GigsViewFormModel view)
        {
             //Add Notification 
            AddNotification(NotificationType.GigUpdated, this.DateTime, this.Venue, this.Genre);
            GenreID = view.Gener;
            Venue = view.Venue;
            DateTime = view.GetDateTime(); 
          
        }

        private void AddNotification(NotificationType notificationType,  DateTime orginalDateTime,  string orignalVenue = "", Genre genre = null )
        {

            Notification newNotification ;
            if (notificationType == NotificationType.GigCanceled)
            {
                newNotification = Notification.CancelGig(this);
            }
            else if (notificationType == NotificationType.GigUpdated)
            {

                newNotification = Notification.UpdateGig(this, orginalDateTime, orignalVenue, genre); 
            }
            else {
                newNotification = Notification.CreateGig(this); 
            }

            var attendees = this.Attendances.Select(a => a.Attendee).ToList();
            foreach (var attendee in attendees)
            {
                attendee.Notify(newNotification);
            }
        }

        
    }

    public class Genre{
        public byte ID {get; set; }
         public string Name { get; set; } 

        
    }
} 