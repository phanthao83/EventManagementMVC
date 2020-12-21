using FluentAssertions;
using GigUnitTestProject.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using EventsManagementWeb.Core.Models;
using EventsManagementWeb.Persistence;
using EventsManagementWeb.Persistence.Repositories; 
namespace GigUnitTestProject.Persistence.Repositories
{
    [TestClass]
    public class TestGigRepository
    {
        Mock<DbSet<Gig>>  _mockGig;
        private GigRepository _gigRepository; 


        [TestInitialize]
        public void IntialData()
        {
            _mockGig = new Mock<DbSet<Gig>>(); 
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Gigs).Returns(_mockGig.Object);
         
            var mockArtist = new Mock<DbSet<ApplicationUser>>();
            var artist1 = new ApplicationUser{ Id = "1" , FullName = "Thao" };
            mockArtist.SetSource(new[] {artist1 });
         //   mockContext.SetupGet(c => c.Users).Returns(mockArtist.Object); 
           

            var mockGener = new Mock<DbSet<Genre>>();
            var gener1 = new Genre { ID = 1, Name = "Cai luong" };
            mockGener.SetSource(new[] { gener1 });
        //    mockContext.SetupGet(c => c.Genres).Returns(mockGener.Object); 


             _gigRepository = new GigRepository(mockContext.Object); 




        }
        [TestMethod]
        public void GetUpcomingGigsByArtist_YesterGig_ShouldReturnNull()
        {
            var gig = new Gig
            {
                ID = 1,
                DateTime = System.DateTime.Now.AddDays(-1),
                GenreID = 1 , 
                ArtistID = "1"
              //  Genre = new Genre {ID = 1 , Name = "Cai luong"}

            };
            _mockGig.SetSource(new[] { gig });

            var gigInfo = _gigRepository.GetUpcomingGigsByArtist("1");
            gigInfo.Should().BeEmpty(); 

        }

        [TestMethod]
        public void GetUpcomingGigsByArtist_Tommorrow_ShouldReturn1()
        {
            var gig = new Gig
            {
                ID = 1,
                DateTime = System.DateTime.Now.AddDays(1),
                GenreID = 1,
                ArtistID = "1"
                //  Genre = new Genre {ID = 1 , Name = "Cai luong"}

            };
            _mockGig.SetSource(new[] { gig });

            var gigInfo = _gigRepository.GetUpcomingGigsByArtist("1");
            gigInfo.Should().BeEquivalentTo(gig); 

        }
         [TestMethod]
        public void GetUpcomingGigsByArtist_TommorrowCanceledGig_ShouldReturnEmpty()
        {
            var gig = new Gig
            {
                ID = 1,
                DateTime = System.DateTime.Now.AddDays(1),
                GenreID = 1,
                ArtistID = "1"
        
            };
            gig.Cancel(); 

            _mockGig.SetSource(new[] { gig });

            var gigInfo = _gigRepository.GetUpcomingGigsByArtist("1");
            gigInfo.Should().BeEmpty(); 
        }
    }
}
