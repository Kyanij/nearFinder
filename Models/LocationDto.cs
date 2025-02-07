using System.Drawing;

namespace NearFinder.Models
{
    public class LocationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Point Geom { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}
