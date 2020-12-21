using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EventsManagementWeb.Core.Dtos ;
using EventsManagementWeb.Core.Repositories; 
namespace EventsManagementWeb.Controllers.Api
{
   // [Authorize]
    public class NotificationController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotificationController(IUnitOfWork uniOfWork)
        {
            _unitOfWork = uniOfWork; 
        }
        [HttpGet]
        public IEnumerable<NotificationDto> GetNotification() 
        {
            return _unitOfWork.Notification.GetUnreadNotificationDto(User.Identity.GetUserId()); 
            
        }

        [HttpPost]
        public IHttpActionResult MarkReadNotification(ApiNotificationDto maxNotificationID)
        {
            //int maxNotificationID = 16; 
            if (maxNotificationID == null) return BadRequest(); 

            var userID = User.Identity.GetUserId();
            var notification = _unitOfWork.Notification
                            .GetUnReadNotification(userID)
                            .ToList();
            foreach (var n in notification) {
                if (n.NotificationID <= maxNotificationID.MaxID) n.MarkRead();
            }
            _unitOfWork.Finish(); 
            return Ok(); 
        }
    }
}
