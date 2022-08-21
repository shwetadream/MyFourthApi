using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFourthApi.Data;
using MyFourthApi.Models;
using MyFourthApi.Repository;
using System.Threading.Tasks;

namespace MyFourthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly JobDbContext _jobDbContext;

        public LocationController(ILocationRepository locationRepository,JobDbContext jobDbContext)
        {
            _locationRepository = locationRepository;
            _jobDbContext = jobDbContext;
        }

        

        [HttpGet("action")]
        public async Task<IActionResult> GetAllLocation()
        {
            var locations= await _locationRepository.GetAllLocationsAsync();
            return Ok(locations);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetLocationById([FromRoute] int id)
        {
            var location = await _locationRepository.GetLocationByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewLocation([FromBody] LocationModel locationModel)
        {
            var id = await _locationRepository.AddLocationAsync(locationModel);

            return CreatedAtAction(nameof(GetLocationById), new { id = id, Controller = "Location" }, id);

        }

        [HttpPut("[action]/{id}")]

        public async Task<IActionResult> UpdateLocation([FromRoute] int id, [FromBody] LocationModel locationModel)
        {

            var result = await _locationRepository.UpdateLocationAsync(id, locationModel);
            if (result == "success")
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
