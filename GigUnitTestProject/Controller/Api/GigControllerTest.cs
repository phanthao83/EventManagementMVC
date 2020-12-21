using FluentAssertions;
using GigUnitTest.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;
using EventsManagementWeb.Controllers.Api;
using EventsManagementWeb.Core.Repositories; 
namespace UnitTestProject1.Controllers
{
    [TestClass]
    public class GigControllerTest
    {
        private GigsController _controller;
        private Mock<IGigRepository> _mockRepository;
        private string _userId;
        public GigControllerTest()
        { }


        //Test Initialize is called before each TestMethod run. 
        //So it make sure the enviroment is reset if you put the intialize for mockRepository in this function more than the contructure
        [TestInitialize]
        public void TestInitialize() 
        { 
            // We must initialize all the objects will used on the function such as User Identity , Repositories
            _mockRepository = new Mock<IGigRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Gig).Returns(_mockRepository.Object);

            _controller = new GigsController(mockUoW.Object);
            _userId = "1";
            _controller.MockCurrentUser("thao", _userId);
        }
        [TestMethod]
        public void Cancel_NoGigWithGivenId_ShouldReturnNotFound()
        {
            var attendDTO = new EventsManagementWeb.Core.Dtos.AttendanceDTO();
            attendDTO.gidID = 1;
            var result = _controller.Cancel(attendDTO);
            result.Should().BeOfType<NotFoundResult>(); 

        }

        [TestMethod]
        public void Cancel_CanceledGig_ShouldReturnNotFound()
        {
            //Do ham Cancel dung ham _unitOfWork.Gig.GetGigOnly(gigID) de xac dinh  lay thong tin Gig.
            //Do do minh phai tao du lieu tra ve cho ham nay 
            var gig = new EventsManagementWeb.Core.Models.Gig();
            gig.Cancel();
            _mockRepository.Setup(r => r.GetGigOnly(1)).Returns(gig); 


            var attendDTO = new EventsManagementWeb.Core.Dtos.AttendanceDTO();
            attendDTO.gidID = 1;
            var result = _controller.Cancel(attendDTO);
            result.Should().BeOfType<NotFoundResult>();

        }

        [TestMethod]
        public void Cancel_CanceledUnauthorizedGig_ShouldReturnNotUnauthorizedUser()
        {
            //Do ham Cancel dung ham _unitOfWork.Gig.GetGigOnly(gigID) de xac dinh  lay thong tin Gig.
            //Do do minh phai tao du lieu tra ve cho ham nay 
            var gig = new EventsManagementWeb.Core.Models.Gig
            {
                    ArtistID = _userId + "_", 
                    ID = 1
            }; 
           _mockRepository.Setup(r => r.GetGigOnly(1)).Returns(gig);


            var attendDTO = new EventsManagementWeb.Core.Dtos.AttendanceDTO();
            attendDTO.gidID = 1;
            var result = _controller.Cancel(attendDTO);
            result.Should().BeOfType<UnauthorizedResult>();

        }

        [TestMethod]
        public void Cancel_ValidGig_ShouldReturnOK()
        {
            //Do ham Cancel dung ham _unitOfWork.Gig.GetGigOnly(gigID) de xac dinh  lay thong tin Gig.
            //Do do minh phai tao du lieu tra ve cho ham nay 
            var gig = new EventsManagementWeb.Core.Models.Gig
            {
                ArtistID = _userId,
                ID = 2
            };
            _mockRepository.Setup(r => r.GetGigOnly(2)).Returns(gig);


            var attendDTO = new EventsManagementWeb.Core.Dtos.AttendanceDTO();
            attendDTO.gidID = 2;
            var result = _controller.Cancel(attendDTO);
            result.Should().BeOfType<OkResult>();

        }
    }
}
