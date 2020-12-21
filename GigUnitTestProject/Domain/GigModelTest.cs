using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using EventsManagementWeb.Core.Models;
namespace GigUnitTestProject.Domain
{
    [TestClass]
    public class GigModelTest
    {
        //This class is used to test the behavior in object Model
        // On the Gig Model , there are an action named Cancel
        // When Cancel is run, the status is updated and the notification is created 
        // This class is make sure all step is done correctly
        [TestMethod]
        public void Cancel_WhenCalled_ShouldSetIsCancelledBeTrue()
        {
            var gig = new Gig(); 
            gig.Cancel();
            gig.IsCancelled.Should().BeTrue(); 

        }
        [TestMethod]
        public void Cancel_WhenCalled_ShouldCreateNotifcationForAllAttendee()
        {
            var gig = new Gig();
            gig.Attendances.Add(new Attendance { Attendee = new ApplicationUser { Id = "1" } });
            gig.Cancel();

            var atttendee = gig.Attendances.Select(a => a.Attendee).ToList();
            atttendee[0].UserNotification.Count().Should().Be(1); 


        }

    }
}
