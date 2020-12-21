using Microsoft.AspNet.Identity;
using System.Web.Http;
using EventsManagementWeb.Core.Dtos ;
using EventsManagementWeb.Core.Repositories; 
namespace EventsManagementWeb.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public GigsController(IUnitOfWork uniOfWork)
        {
            _unitOfWork = uniOfWork; 
            
            
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var gig = _unitOfWork.Gig.GetGigOnly(id); 
            if (gig.IsCancelled)
                return NotFound();
            if (gig.ArtistID != User.Identity.GetUserId())
                return Unauthorized(); 
            gig.Cancel();
            _unitOfWork.Finish();

            return Ok();
        }


        [HttpPost]
        public IHttpActionResult Cancel(AttendanceDTO gidDto)
        {
            var userID = User.Identity.GetUserId();
            int gigID = gidDto.gidID; 
        //1    var gigInfo = _context.Gigs.Single(g => g.ID == gigID && g.ArtistID == userID);
            /* 2  var attendees = _context.Attendances
               .Where(a => a.GigID == gigID)
               .Select(a => a.Attendee)
               .ToList();
           */

            // Refactor cho 2 query 1 + 2 thanh nhu ben duoi . 

            var gigInfo = _unitOfWork.Gig.GetGigOnly(gigID); 
           
          if (gigInfo == null || gigInfo.IsCancelled ) return NotFound();
          if (gigInfo.ArtistID != userID) return Unauthorized(); 
   
            gigInfo.Cancel();
            _unitOfWork.Finish(); 
            return Ok(); 

        }

    }
}
