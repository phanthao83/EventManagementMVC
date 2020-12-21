using Microsoft.AspNet.Identity;
using System.Web.Http;
using EventsManagementWeb.Core.Dtos ;
using EventsManagementWeb.Core.Models;
using EventsManagementWeb.Core.Repositories;
namespace EventsManagementWeb.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
         private readonly IUnitOfWork _unitOfWork; 


        public AttendancesController(IUnitOfWork uniOfWork)
        {
            _unitOfWork = uniOfWork; 
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO gidDto)
        {
           
            var exist =  _unitOfWork.Attendance.FindAttendance(gidDto.gidID, User.Identity.GetUserId());
            if (exist != null )
                return BadRequest("This attandance is existed");
            var attendance = new Attendance
            {
                GigID = gidDto.gidID,
                AttendeeID = User.Identity.GetUserId()

            };
            _unitOfWork.Attendance.Add(attendance);
            _unitOfWork.Finish(); 
            return Ok(); 

        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userID = User.Identity.GetUserId();
            var exist =  _unitOfWork.Attendance.FindAttendance(id, userID);

            if (exist == null)
                return NotFound();
            _unitOfWork.Attendance.Remove(exist);
            _unitOfWork.Finish(); 
             return Ok();

           
        }
       
    }
}
