using System.Collections.Generic;
using EventsManagementWeb.Core.Models;

namespace EventsManagementWeb.Core.Repositories
{
    public interface IFollowRepository
    {
        Following GetFollow(string followeeID, string followerID);
        void AddFollow(string followeeID, string followerID);
        IEnumerable<ApplicationUser> GetFolloweeList(string followerID);
        IEnumerable<ApplicationUser> GetFollowerList(string followeeID);
        IEnumerable<Following> GetFollowingListByFollower(string followerID);
        void Remove(Following follow); 
    }
}
