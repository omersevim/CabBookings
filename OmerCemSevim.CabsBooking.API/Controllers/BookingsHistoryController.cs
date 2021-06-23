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
    public class BookingsHistoryController : ControllerBase
    {
        private readonly IBookingsHistoryService _bookingsHistoryService;
        public BookingsHistoryController(IBookingsHistoryService bookingsHistoryService)
        {
            _bookingsHistoryService = bookingsHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingsHistoryService.GetAllBookings();
            if (bookings.Any())
            {
                return Ok(bookings);
            }
            return NotFound("No bookings were found");
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> AddBooking([FromBody] AddBookingsHistoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var booking = await _bookingsHistoryService.AddBooking(model);
                return Ok(booking);
            }
            return BadRequest("Please check the data you have entered");
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateBooking([FromBody] UpdateBookingsHistoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var booking = await _bookingsHistoryService.UpdateBooking(model);
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
                var booking = await _bookingsHistoryService.DeleteBooking(id);
                return Ok(booking);
            }
            return BadRequest("Please check the data you have entered.");
        }
    }
}
