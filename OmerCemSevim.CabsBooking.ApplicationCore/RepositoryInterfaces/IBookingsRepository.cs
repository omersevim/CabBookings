using ApplicationCore.RepositoryInterfaces;
using OmerCemSevim.CabsBooking.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.ApplicationCore.RepositoryInterfaces
{
    public interface IBookingsRepository : IAsyncRepository<Bookings>
    {
        Task<IEnumerable<Bookings>> GetAllBookings();
        Task<Bookings> GetBookingsByEmail(string email);
        Task<List<Bookings>> GetBookingsByCabId(int cabId);
    }
}
