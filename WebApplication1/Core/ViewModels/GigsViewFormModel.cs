using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using EventsManagementWeb.Controllers;
using EventsManagementWeb.Core.Models; 
 
namespace EventsManagementWeb.Core.ViewModels
{
    public class GigsViewFormModel
    {
        public int ID { get; set; }
        [Required]
        public string Venue { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public byte Gener { get; set; }

        public IEnumerable<Genre> Geners ;
        public DateTime GetDateTime ()
        {
            DateTime d = System.DateTime.Today;
            String abc = Date + " " + Time; 
            System.DateTime.TryParse(  abc, out d);

            return d; 
     
           
        }
        public string Heading { get; set; }
        public string Action
        {
            get
            {
                Expression<Func<GigsController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<GigsController, ActionResult>> create = (c => c.Create(this));
                var action = (ID > 0) ? update : create;
                var actionName = (action.Body as MethodCallExpression).Method.Name;
                return actionName; 

          
            }
 
        }
        //Check whether the current login user is adready attended to this gig
        public bool IsAttending { get; set; }

        // Check whether the current login user has already followed to the artist of this gig.
        public bool IsFollowing { get; set; }
        public bool IsAuthenticated { get; set; }
        public ICollection<GigReviews> GigReview { get; set; }
        public string ArtistName { get; set; }
        public string GenreName { get; set; }
        public string NewComment { get; set; }

    }
}