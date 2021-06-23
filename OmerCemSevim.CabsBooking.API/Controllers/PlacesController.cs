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
    public class PlacesController : ControllerBase
    {
        private readonly IPlacesService _placesService;
        public PlacesController(IPlacesService placesService)
        {
            _placesService = placesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlaces()
        {
            var places = await _placesService.GetAllPlaces();
            if(places.Any())
            {
                return Ok(places);
            }
            return NotFound("No places found");
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> AddPlace([FromBody] AddPlaceRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var place = await _placesService.AddPlace(model);
                return Ok(place);
            }
            return BadRequest("Please check the data you entered");
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdatePlace([FromBody] UpdatePlaceRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var place = await _placesService.UpdatePlace(model);
                return Ok(place);
            }
            return BadRequest("Please check the data you entered");
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeletePlace([FromBody] DeletePlaceRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var place = await _placesService.DeletePlace(model.Id);
                return Ok(place);
            }
            return NotFound("No place with the given ID found");
        }
    }
}
