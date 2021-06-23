using OmerCemSevim.CabsBooking.ApplicationCore.Entities;
using OmerCemSevim.CabsBooking.ApplicationCore.Models.Requests;
using OmerCemSevim.CabsBooking.ApplicationCore.Models.Responses;
using OmerCemSevim.CabsBooking.ApplicationCore.RepositoryInterfaces;
using OmerCemSevim.CabsBooking.ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CabService : ICabService
    {
        private readonly ICabRepository _cabRepository;
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IPlacesRepository _placesRepository;
        public CabService(ICabRepository cabRepository, IBookingsRepository bookingsRepository, IPlacesRepository placesRepository)
        {
            _cabRepository = cabRepository;
            _bookingsRepository = bookingsRepository;
            _placesRepository = placesRepository;
        }
        public async Task<List<CabTypesResponseModel>> GetAllCabs()
        {
            var cabs = await _cabRepository.GetCabTypes();

            var cabList = new List<CabTypesResponseModel>();

            foreach (var cab in cabs)
            {
                cabList.Add(new CabTypesResponseModel
                {
                    CabTypeId = cab.CabTypeId,
                    CabTypeName = cab.CabTypeName
                });
            }
            return cabList;
        }

        public async Task<List<BookingsResponseModel>> GetCabBookings(int id)
        {
            var cabBookings = await _bookingsRepository.GetBookingsByCabId(id);
            if(cabBookings == null)
            {
                throw new Exception("No bookings for this cab found");
            }
            
            var bookingList = new List<BookingsResponseModel>();
            foreach (var booking in cabBookings)
            {
                bookingList.Add(new BookingsResponseModel
                {
                    Id = booking.Id,
                    Email = booking.Email,
                    BookingDate = booking.BookingDate,
                    BookingTime = booking.BookingTime,
                    FromPlaceId = booking.FromPlace,
                    ToPlaceId = booking.ToPlaceId,
                    PickupAddress = booking.PickupAddress,
                    Landmark = booking.Landmark,
                    PickupDate = booking.PickupDate,
                    PickupTime = booking.PickupTime,
                    CabTypeId = booking.CabTypeId,
                    ContactNo = booking.ContactNo,
                    Status = booking.Status,
                    CabTypeName = booking.CabType.CabTypeName,
                    ToPlace = booking.ToPlace.PlaceName,
                    FromPlace = (await _placesRepository.GetById(booking.FromPlace)).PlaceName
            });
            }
            return bookingList;
        }

        public Task<List<BookingsResponseModel>> GetCabBookingsHistory()
        {
            throw new NotImplementedException();
        }
        public async Task<CabTypesResponseModel> AddCab(AddCabRequestModel model)
        {
            //make sure the cab with that name doesn't already exist.
            var dbCab = await _cabRepository.GetCabByName(model.CabTypeName);

            if(dbCab != null)
            {
                throw new Exception("This type of cab already exists in the database.");
            }
            //generate a cab from the model
            var cab = new CabTypes
            {
                CabTypeName = model.CabTypeName
            };

            //add the cab to the database.
            var createdCab = await _cabRepository.Add(cab);

            //create the response model.
            var response = new CabTypesResponseModel
            {
                CabTypeId = createdCab.CabTypeId,
                CabTypeName = createdCab.CabTypeName
            };

            return response;
        }
        public async Task<CabTypesResponseModel> UpdateCab(UpdateCabRequestModel model)
        {
            var cab = await _cabRepository.GetCabByName(model.Name);
            if(cab != null)
            {
                throw new Exception("A cab with that name already exists");
            }

            cab = await _cabRepository.GetById(model.Id);

            if(cab == null)
            {
                throw new Exception("Cab with the given ID does not exist");
            }

            cab.CabTypeName = model.Name;

            var update = await _cabRepository.Update(cab, cab.CabTypeId);

            var response = new CabTypesResponseModel
            {
                CabTypeId = update.CabTypeId,
                CabTypeName = update.CabTypeName
            };

            return response;

        }
        public async Task<CabTypesResponseModel> DeleteCab(int id)
        {
            var cab = await _cabRepository.GetById(id);
            if(cab == null)
            {
                throw new Exception("No cab with given ID exists in the database");
            }

            var delete = await _cabRepository.Delete(cab, cab.CabTypeId);
            if(delete == true)
            {
                var deletedCab = new CabTypesResponseModel
                {
                    CabTypeId = cab.CabTypeId,
                    CabTypeName = cab.CabTypeName
                };

                return deletedCab;
            }
            throw new Exception("There was an error when deleting the cab");
        }
    }
}
