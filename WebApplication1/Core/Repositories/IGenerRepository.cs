using System.Collections.Generic;
using EventsManagementWeb.Core.Models;

namespace EventsManagementWeb.Core.Repositories
{
    public interface IGenerRepository
    {

        IEnumerable<Genre> GetAllGener();
    }
}
