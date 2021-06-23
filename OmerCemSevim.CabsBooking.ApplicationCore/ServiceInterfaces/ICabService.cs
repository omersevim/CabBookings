using OmerCemSevim.CabsBooking.ApplicationCore.Models.Requests;
using OmerCemSevim.CabsBooking.ApplicationCore.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.ApplicationCore.ServiceInterfaces
{
    public interface ICabService
    {
        Task<List<CabTypesResponseModel>> GetAllCabs();
        Task<List<BookingsResponseModel>> GetCabBookings(int id);
        Task<List<BookingsResponseModel>> GetCabBookingsHistory();
        Task<CabTypesResponseModel> AddCab(AddCabRequestModel model);
        Task<CabTypesResponseModel> UpdateCab(UpdateCabRequestModel model);
        Task<CabTypesResponseModel> DeleteCab(int id);
    }
}
