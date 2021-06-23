using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OmerCemSevim.CabsBooking.ApplicationCore.Entities;
using OmerCemSevim.CabsBooking.ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PlacesRepository : EfRepository<Places>, IPlacesRepository
    {
        public PlacesRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Places>> GetAllPlaces()
        {
            var places = await _dbContext.Places.ToListAsync();
            return places;
        }

        public async Task<Places> GetPlaceByName(string name)
        {
            var places = await _dbContext.Places.FirstOrDefaultAsync(c => c.PlaceName == name);
            return places;
        }
    }
}
