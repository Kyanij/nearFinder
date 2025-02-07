using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NearFinder.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationController
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("nearest")]
        public  void GetNearestLocation([FromQuery] double latitue, double longitude)
        {
            //
        }
    }
}
