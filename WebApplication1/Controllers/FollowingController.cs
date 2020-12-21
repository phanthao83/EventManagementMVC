using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using EventsManagementWeb.Core.Repositories; 
namespace EventsManagementWeb.Controllers
{
    public class FollowingController : Controller
    {
       // private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public FollowingController(IUnitOfWork uniOfWork)
        {

            _unitOfWork = uniOfWork; 
        }
        // GET: /Following/
        [Authorize]
        public ActionResult Following()
        {
           //var abc = _context.
            var followeeList = _unitOfWork.Follow.GetFolloweeList(User.Identity.GetUserId());
            return View(followeeList.ToList());
        }
	}
}