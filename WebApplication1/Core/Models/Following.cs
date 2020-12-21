
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 


namespace EventsManagementWeb.Core.Models
{
    public class Following
    {
        
        [Key]
        [Column(Order = 1)]
        public string FolloweeID { get; set; }  //A person who is followed

        [Key]
        [Column(Order = 2)]
        public string FollowerID { get; set; }  //  A person who follow another one.
        public ApplicationUser Followee { get; set; }
        public ApplicationUser Follower { get; set; }

    }
}