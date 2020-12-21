using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using EventsManagementWeb.Core.Repositories;
using EventsManagementWeb.Core.ViewModels; 

namespace EventsManagementWeb.Controllers
{
    public class HomeController : Controller
    {
         private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
            
        }
        public ActionResult Index(string query= null)
        {
            var upcommingGig = _unitOfWork.Gig.GetUpcomingGigsWithArtistAndGenre();

            if (!String.IsNullOrWhiteSpace(query))
            {
                upcommingGig = upcommingGig.Where(
                    g =>
                        g.Artist.FullName.Contains(query) ||
                        g.Venue.Contains(query) ||
                        g.Genre.Name.Contains(query)
                    );

            }
            var userID = User.Identity.GetUserId();
            var attendances = _unitOfWork.Attendance.GetFutureAttendances(userID)
               .ToList()
               .ToLookup(a => a.GigID); 
            //get artist who I followed  (Me is Follower)

            var following = _unitOfWork.Follow.GetFollowingListByFollower(userID)
                            .ToList().ToLookup(f => f.FolloweeID); 
            

            var homeViewModel = new HomeViewModel()
            {
                UpcomingGig = upcommingGig,
                IsAuthenticated = User.Identity.IsAuthenticated,
                Heading = "Upcomming Gigs",
                SearchTerm = query, 
                Attendances = attendances,
                Following = following
            };
            return View("Gigs", homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            ViewBag.Message = "Home Error - Contact IT";
            return View();
        }
    }
}