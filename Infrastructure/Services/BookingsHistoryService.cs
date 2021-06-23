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
    public class BookingsHistoryService : IBookingsHistoryService
    {
        private readonly IBookingsHistoryRepository _bookingsHistoryRepository;
        private readonly IPlacesRepository _placesRepository;
        private readonly ICabRepository _cabRepository;
        public BookingsHistoryService(IBookingsHistoryRepository bookingsHistoryRepository, IPlacesRepository placesRepository, ICabRepository cabRepository)
        {
            _bookingsHistoryRepository = bookingsHistoryRepository;
            _placesRepository = placesRepository;
            _cabRepository = cabRepository;
        }
        public async Task<BookingsHistoryResponseModel> AddBooking(AddBookingsHistoryRequestModel model)
        {
            var place = await _placesRepository.GetPlaceByName(model.FromPlace);
            if (place == null)
            {
                throw new Exception("Pick up service from the given location does not exist");
            }
            var destination = await _placesRepository.GetPlaceByName(model.ToPlace);
            if (destination == null)
            {
                throw new Exception("Drop off service to the given destination does not exist");
            }
            var cab = await _cabRepository.GetCabByName(model.CabTypeName);
            if (cab == null)
            {
                throw new Exception("No cab with the given model exists.");
            }
            var booking = new BookingsHistory
            {
                Email = model.Email,
                BookingDate = DateTime.Now,
                BookingTime = model.BookingTime,
                FromPlace = place.PlaceId,
                ToPlaceId = destination.PlaceId,
                PickupAddress = model.PickupAddress,
                Landmark = model.Landmark,
                PickupDate = model.PickupDate,
                PickupTime = model.PickupTime,
                CabTypeId = cab.CabTypeId,
                ContactNo = model.ContactNo,
                Status = model.Status,
                Feedback = model.Feedback,
                CompTime = model.CompTime,
                Charge = model.Charge
            };
            var dbBooking = await _bookingsHistoryRepository.Add(booking);

            var response = new BookingsHistoryResponseModel
            {
                Id = dbBooking.Id,
                Email = dbBooking.Email,
                BookingDate = dbBooking.BookingDate,
                BookingTime = dbBooking.BookingTime,
                FromPlaceId = dbBooking.FromPlace,
                ToPlaceId = dbBooking.ToPlaceId,
                PickupAddress = dbBooking.PickupAddress,
                Landmark = dbBooking.Landmark,
                PickupDate = dbBooking.PickupDate,
                PickupTime = dbBooking.PickupTime,
                CabTypeId = dbBooking.CabTypeId,
                ContactNo = dbBooking.ContactNo,
                Status = dbBooking.Status,
                Feedback = dbBooking.Feedback,
                CompTime = dbBooking.CompTime,
                Charge = dbBooking.Charge
            };
            return response;
        }

        public async Task<BookingsHistoryResponseModel> DeleteBooking(int id)
        {
            var dbBooking = await _bookingsHistoryRepository.GetById(id);
            if (dbBooking == null)
            {
                throw new Exception("No booking with the given ID exists");
            }

            var delete = await _bookingsHistoryRepository.Delete(dbBooking, dbBooking.Id);
            if (delete == true)
            {
                var deletedBooking = new BookingsHistoryResponseModel
                {
                    Id = dbBooking.Id,
                    Email = dbBooking.Email,
                    BookingDate = dbBooking.BookingDate,
                    BookingTime = dbBooking.BookingTime,
                    FromPlaceId = dbBooking.FromPlace,
                    ToPlaceId = dbBooking.ToPlaceId,
                    PickupAddress = dbBooking.PickupAddress,
                    Landmark = dbBooking.Landmark,
                    PickupDate = dbBooking.PickupDate,
                    PickupTime = dbBooking.PickupTime,
                    CabTypeId = dbBooking.CabTypeId,
                    ContactNo = dbBooking.ContactNo,
                    Status = dbBooking.Status
                };
                return deletedBooking;
            }
            throw new Exception("There was an error when deleting the booking.");
        }

        public async Task<List<BookingsHistoryResponseModel>> GetAllBookings()
        {
            var bookings = await _bookingsHistoryRepository.GetAllBookings();
            if (bookings == null)
            {
                throw new Exception("No bookings were found");
            }

            var bookingsList = new List<BookingsHistoryResponseModel>();

            foreach (var booking in bookings)
            {
                bookingsList.Add(new BookingsHistoryResponseModel
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
                    Feedback = booking.Feedback,
                    CompTime = booking.CompTime,
                    Charge = booking.Charge
                });
            }
            return bookingsList;
        }

        public async Task<BookingsHistoryResponseModel> UpdateBooking(UpdateBookingsHistoryRequestModel model)
        {
            var dbBooking = await _bookingsHistoryRepository.GetById(model.Id);
            if (dbBooking == null)
            {
                throw new Exception("No booking with given ID found");
            }
            var place = await _placesRepository.GetPlaceByName(model.FromPlace);
            if (place == null)
            {
                throw new Exception("Pick up service from the given location does not exist");
            }
            var destination = await _placesRepository.GetPlaceByName(model.ToPlace);
            if (destination == null)
            {
                throw new Exception("Drop off service to the given destination does not exist");
            }
            var cab = await _cabRepository.GetCabByName(model.CabTypeName);
            if (cab == null)
            {
                throw new Exception("No cab with the given model exists.");
            }

            dbBooking.Email = model.Email;
            dbBooking.BookingDate = DateTime.Now;
            dbBooking.BookingTime = model.BookingTime;
            dbBooking.FromPlace = place.PlaceId;
            dbBooking.ToPlaceId = destination.PlaceId;
            dbBooking.PickupAddress = model.PickupAddress;
            dbBooking.Landmark = model.Landmark;
            dbBooking.PickupDate = model.PickupDate;
            dbBooking.PickupTime = model.PickupTime;
            dbBooking.CabTypeId = cab.CabTypeId;
            dbBooking.ContactNo = model.ContactNo;
            dbBooking.Status = model.Status;
            dbBooking.Charge = model.Charge;
            dbBooking.Feedback = model.Feedback;
            dbBooking.CompTime = model.CompTime;

            var updatedBooking = await _bookingsHistoryRepository.Update(dbBooking, dbBooking.Id);

            var response = new BookingsHistoryResponseModel
            {
                Id = dbBooking.Id,
                Email = dbBooking.Email,
                BookingDate = dbBooking.BookingDate,
                BookingTime = dbBooking.BookingTime,
                FromPlaceId = dbBooking.FromPlace,
                ToPlaceId = dbBooking.ToPlaceId,
                PickupAddress = dbBooking.PickupAddress,
                Landmark = dbBooking.Landmark,
                PickupDate = dbBooking.PickupDate,
                PickupTime = dbBooking.PickupTime,
                CabTypeId = dbBooking.CabTypeId,
                ContactNo = dbBooking.ContactNo,
                Status = dbBooking.Status,
                Feedback = dbBooking.Feedback,
                CompTime = dbBooking.CompTime,
                Charge = dbBooking.Charge
            };
            return response;
        }
    }
}
