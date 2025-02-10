using NetTopologySuite.Geometries;

namespace NearFinder.Persistance
{
    public class Location
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Default UUID generation
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Point Geom { get; set; } // PostGIS Geography (Point)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Default timestamp
    }
}
