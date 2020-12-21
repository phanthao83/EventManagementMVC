using EventsManagementWeb.Core.Models;
using EventsManagementWeb.Core.Repositories;
namespace EventsManagementWeb.Persistence.Repositories
{
    public class GenerRepository : IGenerRepository
    {
         private readonly ApplicationDbContext _context;
         public GenerRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

         public System.Collections.Generic.IEnumerable<Genre> GetAllGener() 
         {
             return _context.Genres; 
         }
    }
}