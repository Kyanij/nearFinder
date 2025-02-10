using MediatR;
using NearFinder.Models;

namespace NearFinder.Messaging.Location
{
    public class UserLocationInput : IRequest<LocationDto>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public UserLocationInput(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
