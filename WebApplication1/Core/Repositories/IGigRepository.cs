using System.Collections.Generic;
using EventsManagementWeb.Core.Models; 



namespace EventsManagementWeb.Core.Repositories
{
    public interface IGigRepository
    {
        Gig GetGigOnly(int gigId);
        IEnumerable<Gig> GetUpcomingGigsWithArtistAndGenre();
        Gig GetGigWithAttendances(int gigId);
        IEnumerable<Gig> GetAttendedGigWithArtistAndGenre(string userId);
         IEnumerable<Gig> GetGigWithArtistAndGenreByArtist( string artistId , int gigId);
        Gig GetGigDetailWithAttendanceAndGenre(int gigID);
        void Add(Gig gig); 

    }
}
