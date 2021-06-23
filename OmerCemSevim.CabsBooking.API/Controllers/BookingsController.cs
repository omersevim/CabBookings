using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OmerCemSevim.CabsBooking.ApplicationCore.Models.Requests;
using OmerCemSevim.CabsBooking.ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsService _bookingsService;
        public BookingsController(IBookingsService bookingsService)
        {
            _bookingsService = bookingsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingsService.GetAllBookings();
            if (bookings.Any())
            {
                return Ok(bookings);
            }
            return NotFound("No bookings were found");
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> AddBooking([FromBody] AddBookingsRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var booking = await _bookingsService.AddBooking(model);
                return Ok(booking);
            }
            return BadRequest("Please check the data you have entered");
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateBooking([FromBody] UpdateBookingRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var booking = await _bookingsService.UpdateBooking(model);
                return Ok(booking);
            }
            return BadRequest("Please check the data you have entered.");
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            if (ModelState.IsValid)
            {
                var booking = await _bookingsService.DeleteBooking(id);
                return Ok(booking);
            }
            return BadRequest("Please check the data you have entered.");
        }
    }
}
