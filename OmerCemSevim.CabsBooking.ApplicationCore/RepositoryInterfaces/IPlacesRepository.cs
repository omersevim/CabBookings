using ApplicationCore.RepositoryInterfaces;
using OmerCemSevim.CabsBooking.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.ApplicationCore.RepositoryInterfaces
{
    public interface IPlacesRepository : IAsyncRepository<Places>
    {
        Task<IEnumerable<Places>> GetAllPlaces();
        Task<Places> GetPlaceByName(string name);
    }
}
