using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmerCemSevim.CabsBooking.ApplicationCore.Entities;
using OmerCemSevim.CabsBooking.ApplicationCore.Models.Requests;
using OmerCemSevim.CabsBooking.ApplicationCore.Models.Responses;
using OmerCemSevim.CabsBooking.ApplicationCore.RepositoryInterfaces;
using OmerCemSevim.CabsBooking.ApplicationCore.ServiceInterfaces;
namespace Infrastructure.Services
{
    public class PlacesService : IPlacesService
    {
        private readonly IPlacesRepository _placesRepository;
        public PlacesService(IPlacesRepository placesRepository)
        {
            _placesRepository = placesRepository;
        }
        public async Task<PlacesResponseModel> AddPlace(AddPlaceRequestModel model)
        {
            var dbPlace = await _placesRepository.GetPlaceByName(model.Name);
            if(dbPlace != null)
            {
                throw new Exception("A place with the given name already exists in the database");
            }

            var place = new Places
            {
                PlaceName = model.Name
            };

            var createdPlace = await _placesRepository.Add(place);

            var response = new PlacesResponseModel
            {
                PlaceId = createdPlace.PlaceId,
                PlaceName = createdPlace.PlaceName
            };
            return response;
        }

        public async Task<PlacesResponseModel> DeletePlace(int id)
        {
            var place = await _placesRepository.GetById(id);
            if (place == null)
            {
                throw new Exception("No cab with given ID exists in the database");
            }

            var delete = await _placesRepository.Delete(place, place.PlaceId);
            if (delete == true)
            {
                var deletedPlace = new PlacesResponseModel
                {
                    PlaceId = place.PlaceId,
                    PlaceName = place.PlaceName
                };

                return deletedPlace;
            }
            throw new Exception("There was an error when deleting the cab");
        }

        public async Task<List<PlacesResponseModel>> GetAllPlaces()
        {
            var places = await _placesRepository.GetAllPlaces();
            
            var placeList = new List<PlacesResponseModel>();

            foreach (var place in places)
            {
                placeList.Add(new PlacesResponseModel
                {
                    PlaceId = place.PlaceId,
                    PlaceName = place.PlaceName
                });
            }
            return placeList;
        }

        public async Task<PlacesResponseModel> UpdatePlace(UpdatePlaceRequestModel model)
        {
            var place = await _placesRepository.GetPlaceByName(model.Name);
            if(place != null)
            {
                throw new Exception("A place with that name already exists");
            }

            place = await _placesRepository.GetById(model.Id);
            if(place == null)
            {
                throw new Exception("No place with the given ID found");
            }

            place.PlaceName = model.Name;

            var update = await _placesRepository.Update(place, place.PlaceId);

            var response = new PlacesResponseModel
            {
                PlaceId = update.PlaceId,
                PlaceName = update.PlaceName
            };
            return response;
        }
    }
}
