using System.Collections.Generic;
using EventsManagementWeb.Core.Models; 
namespace EventsManagementWeb.Core.Repositories
{
    public interface IAttandanceRepository
    {
        Attendance FindAttendance(int gigId, string userID);
        IEnumerable<Attendance> GetFutureAttendances(string userID);
        void Add(Attendance attendance);
        void Remove(Attendance attendance); 
    }
}
