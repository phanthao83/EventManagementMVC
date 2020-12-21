using Microsoft.AspNet.Identity;
using System.Web.Http;
using EventsManagementWeb.Core.Dtos ;
using EventsManagementWeb.Core.Repositories; 
namespace EventsManagementWeb.Controllers.Api
{

    public class FollowController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public FollowController(IUnitOfWork uniOfWork)
        {
             _unitOfWork = uniOfWork; 
            
        }

        [HttpPost]
        public IHttpActionResult Attend(FollowDto followDto)
        {
           // The login user will follow the followee Dto 
            var exist = _unitOfWork.Follow.GetFollow(followDto.followeeID, User.Identity.GetUserId());
            if (exist != null)
                return BadRequest("This attandance is existed");
            _unitOfWork.Follow.AddFollow(followDto.followeeID, User.Identity.GetUserId());
            _unitOfWork.Finish(); 
            return Ok(); 

        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
           var userID = User.Identity.GetUserId();
           var following = _unitOfWork.Follow.GetFollow(id, User.Identity.GetUserId());
            if (following == null) return NotFound();
            _unitOfWork.Follow.Remove(following);
            _unitOfWork.Finish(); 
            return Ok(id); 
        }


      
    }
}