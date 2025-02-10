using MediatR;
using Microsoft.AspNetCore.Mvc;
using NearFinder.Messaging.Location;

namespace NearFinder.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("nearest")]
        public async Task<IActionResult> GetNearestLocation([FromQuery] double latitude, [FromQuery] double longitude)
        {
            var query = new UserLocationInput(latitude, longitude);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound(new { message = "No nearby locations found." });
            }

            return Ok(result);
        }
    }
}
