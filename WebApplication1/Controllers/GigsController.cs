using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using EventsManagementWeb.Core.Models;
using EventsManagementWeb.Core.Repositories;
using EventsManagementWeb.Core.ViewModels; 
namespace EventsManagementWeb.Controllers
{
	public class GigsController : Controller
	{
        private readonly IUnitOfWork _unitOfWork; 
		//
        public GigsController(IUnitOfWork uniOfWork) 
		{
            _unitOfWork = uniOfWork; 
		}
		// GET: /Gigs/
		[Authorize]
		public ActionResult Create()
		{
						   
			var viewModel = new GigsViewFormModel
			{
				 Geners = _unitOfWork.Gener.GetAllGener().ToList(), 
                  Heading = "GigsController - Create a gig"
				 
			};
			return View(viewModel);
		}

        [Authorize]
        [HttpPost]
        public ActionResult Search(HomeViewModel view)
        {
            return RedirectToAction("Index", "Home", new { query = view.SearchTerm });
        }


        [Authorize]
        [HttpPost]
        public ActionResult Comment(GigsViewFormModel view)
        {
            var newGigComment = new GigReviews(view.ID, User.Identity.GetUserId(), view.NewComment);
            _unitOfWork.GigReviews.Add(newGigComment); 
            _unitOfWork.Finish(); 


            return RedirectToAction("GigDetail", "Gigs", new { Id = view.ID });
        }


        // GET: /Gigs/
        [Authorize]
		[HttpPost]
		public ActionResult Create( GigsViewFormModel view)
		{
			if (!ModelState.IsValid)
			{

                view.Geners = _unitOfWork.Gener.GetAllGener(); 
				return View("Create", view); 
			}

            
			var newGig = new Gig() ;
            newGig.Create(User.Identity.GetUserId(), view);
            _unitOfWork.Gig.Add(newGig);
            _unitOfWork.Finish(); 

            return RedirectToAction("UpcomingGig", "Gigs"); 
		}

		// GET: /Gigs/
		[Authorize]
		public ActionResult Attending()
		{  
			var userID = User.Identity.GetUserId();
           
          	var homeGigview = new HomeViewModel()
			{
                UpcomingGig = _unitOfWork.Gig.GetAttendedGigWithArtistAndGenre(userID).ToList(),
                Attendances = _unitOfWork.Attendance.GetFutureAttendances(userID).ToList().ToLookup(a=>a.GigID),
                Following = _unitOfWork.Follow .GetFollowingListByFollower(userID).ToList().ToLookup(a => a.FolloweeID),
				IsAuthenticated = User.Identity.IsAuthenticated, 
				Heading = "I go to gig " 
			};

          
 
			return View("Gigs", homeGigview); 


		}
        // GET: /Gigs/
        [Authorize]
        public ActionResult UpcomingGig()
        {
            var myUpcomingGig = _unitOfWork.Gig
                .GetGigWithArtistAndGenreByArtist(User.Identity.GetUserId(),0)
                .ToList();
            return View( myUpcomingGig);


        }

        [Authorize]
        public ActionResult Update(int gigId) {

            var userID = User.Identity.GetUserId();
           // var gigInfo = _context.Gigs.Single(g => g.ID == gigId && g.ArtistID == userID);
            var gigInfo = _unitOfWork.Gig.GetGigOnly(gigId); 
           
            var viewModel = new GigsViewFormModel
            {
                Heading = "Update a gig",
                Geners = _unitOfWork.Gener.GetAllGener().ToList(),
                Venue = gigInfo.Venue,
                Date = gigInfo.DateTime.ToString("d MMM yyyy"),
                Time = gigInfo.DateTime.ToString("HH:MM"),
                Gener = gigInfo.GenreID, 
                ID = gigId

            };
            return View("Create", viewModel);
        }

        // GET: /Gigs/
        [Authorize]
        [HttpPost]
        public ActionResult Update(GigsViewFormModel view)
        {
            if (!ModelState.IsValid)
            {
                view.Geners = _unitOfWork.Gener.GetAllGener().ToList(); 
                return View("Create", view);
            }
            var gigID = view.ID; 
            var userID = User.Identity.GetUserId();
            var gigInfo = _unitOfWork.Gig.GetGigDetailWithAttendanceAndGenre(gigID);

            // update
            gigInfo.Update(view);
            _unitOfWork.Finish(); 

            return RedirectToAction("UpcomingGig", "Gigs");
        }


        public ActionResult GigDetail( int  Id)
        { 
         //   int gigID = gig.Id; 
            var searchGigs = _unitOfWork.Gig.GetGigWithArtistAndGenreByArtist(null, Id).ToList();
            if (searchGigs.Count != 1) {
                return RedirectToAction("Error", "Home"); 
                
            }
            var gig = searchGigs.ElementAt(0);

            //Check whether the logined user follow the artist of gig
            var following = _unitOfWork.Follow.GetFollow(gig.ArtistID, User.Identity.GetUserId());
            var attendance = _unitOfWork.Attendance.FindAttendance(gig.ID, User.Identity.GetUserId()); 
            var gigView = new GigsViewFormModel()
            {
                ID = gig.ID,
                Venue = gig.Venue,
                ArtistName = gig.Artist.FullName,
                GenreName = gig.Genre.Name, 
                GigReview = gig.GigReview,
                Date = gig.DateTime.Date.ToShortDateString (),
                Time = gig.DateTime.ToShortTimeString(), 
                IsFollowing = following == null ? false : true ,
                IsAttending = attendance == null ? false : true, 
                IsAuthenticated = User.Identity.IsAuthenticated
                

            }; 
            return View("GigDetail", gigView); 

           
        }
	}
}