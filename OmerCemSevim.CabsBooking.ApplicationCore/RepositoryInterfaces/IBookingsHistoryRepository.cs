using ApplicationCore.RepositoryInterfaces;
using OmerCemSevim.CabsBooking.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.ApplicationCore.RepositoryInterfaces
{
    public interface IBookingsHistoryRepository: IAsyncRepository<BookingsHistory>
    {
        Task<IEnumerable<BookingsHistory>> GetAllBookings();
        Task<BookingsHistory> GetBookingsByEmail(string email);
        Task<List<BookingsHistory>> GetBookingsByCabId(int cabId);
    }
}
