using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EventsManagementWeb.Core.Models;
using EventsManagementWeb.Core.Dtos;
using EventsManagementWeb.Core.Repositories;
namespace EventsManagementWeb.Persistence.Repositories
{
    public class NotificationRepository: INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public IEnumerable<UserNotification> GetUnReadNotification(string userID)
        {
            if (userID == null)
            {
                return _context.UserNotification; 
            }
            return _context.UserNotification
                .Where(un => un.UserID == userID && un.IsRead == false);
        }
        public IEnumerable<Notification>  GetUnReadNotificationWithArtistAndGener(string userID) 
        { 
            return  _context.UserNotification
                .Where(un => un.UserID == userID && un.IsRead == false)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .Include (n => n.OrginalGener);
        }
        public IEnumerable<NotificationDto> GetUnreadNotificationDto(string userID )
        {
            var notification = GetUnReadNotificationWithArtistAndGener(userID).ToList();
            /* Cach 1 : 
             * return notification.Select(n => new NotificationDto()
               {
                   DateTime = n.DateTime,
                   Type = n.Type,
                   OrginalVenue = n.OrginalVenue,
                   OrginalDateTime = n.OrginalDateTime,
               
                   Gig = new GigDto  
                   { 
                       Id = n.Gig.ID, 
                       Venue = n.Gig.Venue, 
                       DateTime = n.Gig.DateTime, 
                       IsCancelled = n.Gig.IsCancelled, 

                       Artist = new ArtistDto
                       {
                           FullName = n.Gig.Artist.FullName,
                           Id = n.Gig.Artist.Id 
                       }
                
                   }

               }); 
             * */
            /* Cach 2 : Install : install-package AutoMapper ( chay cai nay trong Package Manager Console */

            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<ApplicationUser, ArtistDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationDto>();

            return notification.Select(Mapper.Map<Notification, NotificationDto>);
        }
    }
}