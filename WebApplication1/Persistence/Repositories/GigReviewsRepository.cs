using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EventsManagementWeb.Core.Models;
using EventsManagementWeb.Core.Repositories;
namespace EventsManagementWeb.Persistence.Repositories
{
    public class GigReviewsRepository : IGigReviewRepository
    {
        private readonly IApplicationDbContext _context;
        public GigReviewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(GigReviews review) {
            _context.GigReviews.Add(review); 
           
        }
    }
}