using OmerCemSevim.CabsBooking.ApplicationCore.Models.Requests;
using OmerCemSevim.CabsBooking.ApplicationCore.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.ApplicationCore.ServiceInterfaces
{
    public interface IBookingsService
    {
        Task<List<BookingsResponseModel>> GetAllBookings();
        Task<BookingsResponseModel> AddBooking(AddBookingsRequestModel model);
        Task<BookingsResponseModel> DeleteBooking(DeleteBookingRequestModel model);
        Task<BookingsResponseModel> UpdateBooking(UpdateBookingRequestModel model);
    }
}
