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
    public class CabController : ControllerBase
    {
        private readonly ICabService _cabService;

        public CabController(ICabService cabService)
        {
            _cabService = cabService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCabs()
        {
            var cabs = await _cabService.GetAllCabs();
            if (cabs.Any())
            {
                return Ok(cabs);
            }
            return NotFound("No cabs found");
        }
        [HttpGet]
        [Route("{id}/bookings")]
        public async Task<IActionResult> GetCabBookings(int id)
        {
            if (ModelState.IsValid)
            {
                var bookings = await _cabService.GetCabBookings(id);
                if (bookings.Any())
                {
                    return Ok(bookings);
                }
                return NotFound("No bookings for this cab found.");
            }
            return BadRequest("Please check the data you have entered.");
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> AddCab([FromBody] AddCabRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var cab = await _cabService.AddCab(model);
                return Ok(cab);
            }
            return BadRequest("Please check the data you entered");

        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateCab([FromBody] UpdateCabRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var cab = await _cabService.UpdateCab(model);
                return Ok(cab);
            }
            return BadRequest("Please check the data you entered");

        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteCab([FromBody] CabIdModel model)
        {
            if (ModelState.IsValid)
            {
                var cab = await _cabService.DeleteCab(model.Id);
                return Ok(cab);
            }
            return BadRequest("Please check the data you entered");

        }
    }
}
