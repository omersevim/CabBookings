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
    public class CabRepository : EfRepository<CabTypes>, ICabRepository
    {
        public CabRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<CabTypes>> GetCabTypes()
        {
            var cabs = await _dbContext.CabTypes.ToListAsync();
            return cabs;
        }

        public async Task<CabTypes> GetCabByName(string name)
        {
            var cab = await _dbContext.CabTypes.FirstOrDefaultAsync(c => c.CabTypeName == name);
            return cab;
        }
    }
}
