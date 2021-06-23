using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OmerCemSevim.CabsBooking.ApplicationCore.Entities;
using OmerCemSevim.CabsBooking.ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookingsHistoryRepository: EfRepository<BookingsHistory>, IBookingsHistoryRepository
    {
        public BookingsHistoryRepository(CabsBookingDbContext dbContext):base(dbContext)
        {

        }

        public async Task<IEnumerable<BookingsHistory>> GetAllBookings()
        {
            var bookings = await _dbContext.BookingsHistories.ToListAsync();
            return bookings;
        }

        public async Task<List<BookingsHistory>> GetBookingsByCabId(int cabId)
        {
            var bookings = await _dbContext.BookingsHistories.Include(b => b.CabType).Include(b => b.ToPlace).Where(b => b.CabTypeId == cabId).ToListAsync();
            return bookings;
        }

        public async Task<BookingsHistory> GetBookingsByEmail(string email)
        {
            var booking = await _dbContext.BookingsHistories.FirstOrDefaultAsync(b => b.Email == email);
            return booking;
           
        }
    }
}
