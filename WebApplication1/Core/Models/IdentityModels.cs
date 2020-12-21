﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading.Tasks;
namespace EventsManagementWeb.Core.Models
    
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
      /*  public async Task<ClaimsIdentity> GenerateIdentityAsync( UserManager <ApplicationUser>){
            
          //  var userIndentity = await RoleManager.
            return null; 
      }*/
        public string FullName { get; set; }

        public ICollection<Following> Followers { get; set; }
        public ICollection<Following> Followees {  get; set; }
        public ICollection<UserNotification> UserNotification { get; set; }
        public int NoOfNotification { get { return 10; } }
        public ApplicationUser()
        {
            Followees = new  Collection<Following>();
            Followers = new Collection<Following>();
            UserNotification = new Collection<UserNotification>(); 

        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(  UserManager <ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }

        public void Notify(Notification notification)
        {
          //  UserNotification u = new UserNotification()
            UserNotification.Add(new UserNotification(this, notification)); 

        }
        public int GetNumberNotification()
        {
            return 10; 
        }
      
    }


    
}