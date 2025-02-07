using MediatR;

namespace NearFinder.Messaging.Location
{
    public class UserLocationInput : IRequest
    {
        public double Latitdue { get; set; }
        public double Longitdue { get; set; }
    }
}
