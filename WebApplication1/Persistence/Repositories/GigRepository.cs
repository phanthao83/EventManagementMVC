using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EventsManagementWeb.Core.Models;
using EventsManagementWeb.Core.Repositories;
namespace EventsManagementWeb.Persistence.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly IApplicationDbContext _context;
        public GigRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public Gig GetGigOnly(int gigId)
        {
            return _context.Gigs
                 .SingleOrDefault(g => g.ID == gigId); 
       
        }
        public IEnumerable<Gig> GetUpcomingGigsWithArtistAndGenre()
        {
            return _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now); 
        }
        public Gig GetGigWithAttendances(int gigId)
        {
            return _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(g => g.ID == gigId); 
        }
        public System.Collections.Generic.IEnumerable<Gig> GetAttendedGigWithArtistAndGenre(string userId)

        {
            return _context.Attendances
                .Where(b => b.AttendeeID == userId)
                 .Select(b => b.Gig)
                 .Include(g => g.Artist)
                 .Include(g => g.Genre); 


        }

        public IEnumerable<Gig> GetGigWithArtistAndGenreByArtist(string artistId , int gigId )
        {
            if (gigId == 0 )
            {
              return _context.Gigs
                    .Include(g => g.Artist)
                    .Include(g => g.Genre)
                    
                    .Where(g => g.ArtistID == artistId && g.DateTime > DateTime.Now); 

            }else{
            
               return _context.Gigs
                    .Include(g => g.Artist)
                    .Include(g => g.Genre)
                    .Include (g => g.GigReview)
                    .Where(g => g.ID == gigId); 

           }
  
        
        }

        public Gig GetGigDetailWithAttendanceAndGenre(int gigID)
        {
            return _context.Gigs
                .Include(g => g.Genre)
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(g => g.ID == gigID); 
        }
        
        public void Add(Gig gig) 
        {
            _context.Gigs.Add(gig); 
        }
        public IEnumerable<Gig> GetUpcomingGigsByArtist(string artistId)
        {
            return _context.Gigs
                    .Where(g => g.ArtistID == artistId && g.DateTime > DateTime.Now && !g.IsCancelled)
                     .Include(g => g.Artist)
                    .Include(g => g.Genre)
                    .ToList(); 
            


           
        }
    }
}