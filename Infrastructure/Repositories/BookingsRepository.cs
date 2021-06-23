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
    public class BookingsRepository : EfRepository<Bookings>, IBookingsRepository
    {
        public BookingsRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<IEnumerable<Bookings>> GetAllBookings()
        {
            var bookings = await _dbContext.Bookings.ToListAsync();
            return bookings;
        }
        public async Task<Bookings> GetBookingsByEmail(string email)
        {
            var booking = await _dbContext.Bookings.FirstOrDefaultAsync(b => b.Email == email);
            return booking;
        }
        public async Task<List<Bookings>> GetBookingsByCabId(int cabId)
        {
            var bookings = await _dbContext.Bookings.Include(b => b.CabType).Include(b => b.ToPlace).Where(b => b.CabTypeId == cabId).ToListAsync();
            return bookings;
        }

    }
}
