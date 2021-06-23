using OmerCemSevim.CabsBooking.ApplicationCore.Models.Requests;
using OmerCemSevim.CabsBooking.ApplicationCore.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.ApplicationCore.ServiceInterfaces
{
    public interface IPlacesService
    {
        Task<List<PlacesResponseModel>> GetAllPlaces();
        Task<PlacesResponseModel> AddPlace(AddPlaceRequestModel model);
        Task<PlacesResponseModel> UpdatePlace(UpdatePlaceRequestModel model);
        Task<PlacesResponseModel> DeletePlace(int id);
    }
}
