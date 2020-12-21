using System.Data.Entity;
using System.Linq;
using EventsManagementWeb.Core.Models;
using EventsManagementWeb.Core.Repositories;
namespace EventsManagementWeb.Persistence.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly ApplicationDbContext _context;
       
        public FollowRepository(ApplicationDbContext context)
        {
            _context = context; 
            
        }

        public Following GetFollow(string followeeID, string followerID)
        {
            return _context.Following.SingleOrDefault(f => f.FolloweeID == followeeID && f.FollowerID == followerID); 
            //return _context.Following.Find(followeeID, followerID); 
        }

        public void AddFollow(string followeeID, string followerID) {
            var following = new Following
            {
                FolloweeID = followeeID,
                FollowerID = followerID

            };
            _context.Following.Add(following);
          
        }

        public System.Collections.Generic.IEnumerable<ApplicationUser> GetFolloweeList(string followerID)
        {
            return _context.Following
                .Include(f => f.Followee)
                .Where(f => f.FollowerID == followerID)
                .Select(f => f.Followee); 
         
        
        }

        public System.Collections.Generic.IEnumerable<ApplicationUser> GetFollowerList(string followeeID)
        {
            return _context.Following
                .Include(f => f.Follower)
                .Where(f => f.FolloweeID == followeeID)
                .Select(f => f.Follower);


        }
        public System.Collections.Generic.IEnumerable<Following> GetFollowingListByFollower(string followerID) 
        {
            return _context.Following
              .Where(f => f.FollowerID == followerID); 
        }

        public void Remove(Following follow)
        {
            _context.Following.Remove(follow); 
        }

    }
}