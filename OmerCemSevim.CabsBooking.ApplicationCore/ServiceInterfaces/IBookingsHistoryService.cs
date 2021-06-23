using OmerCemSevim.CabsBooking.ApplicationCore.Models.Requests;
using OmerCemSevim.CabsBooking.ApplicationCore.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.ApplicationCore.ServiceInterfaces
{
    public interface IBookingsHistoryService
    {
        Task<List<BookingsHistoryResponseModel>> GetAllBookings();
        Task<BookingsHistoryResponseModel> AddBooking(AddBookingsHistoryRequestModel model);
        Task<BookingsHistoryResponseModel> DeleteBooking(int id);
        Task<BookingsHistoryResponseModel> UpdateBooking(UpdateBookingsHistoryRequestModel model);
    }
}
