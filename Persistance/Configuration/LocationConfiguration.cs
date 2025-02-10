using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace NearFinder.Persistance.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(e => e.Geom)
               .HasColumnType("geometry(Point, 4326)"); // Define PostGIS geometry type

            builder.HasIndex(l => l.Geom)
            .HasMethod("GIST")
            .HasDatabaseName("idx_locations_geom");
        }
    }
}


