using System.Linq;
using EventsManagementWeb.Core.Models;
using EventsManagementWeb.Core.Repositories; 
namespace EventsManagementWeb.Persistence.Repositories
{
    public class AttandanceRepository : IAttandanceRepository
    {
        private readonly ApplicationDbContext _context;
        public AttandanceRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public Attendance FindAttendance(int gigId, string userID)
        {
            return _context.Attendances.SingleOrDefault(a => a.AttendeeID == userID && a.GigID == gigId); 
        }

        public System.Collections.Generic.IEnumerable<Attendance> GetFutureAttendances(string userID)
        {
            return _context.Attendances.Where(a => a.AttendeeID == userID && a.Gig.DateTime > System.DateTime.Now); 
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance); 
        }

        public void Remove(Attendance attendance)
        {
            _context.Attendances.Remove(attendance); 
        }

    }
}