using MediatR;
using Microsoft.EntityFrameworkCore;
using NearFinder.Models;
using NearFinder.Persistance;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql.EntityFrameworkCore.PostgreSQL.NetTopologySuite;


namespace NearFinder.Messaging.Location
{
    public class UserLocationHandler : IRequestHandler<UserLocationInput, LocationDto?>
    {
        private readonly IDbContextFactory<NearFinderDbContext> _dbContextFactory;

        public UserLocationHandler(IDbContextFactory<NearFinderDbContext> dbContextFactory)
        {
            this._dbContextFactory = dbContextFactory;
        }
        public async Task<LocationDto?> Handle(UserLocationInput request, CancellationToken cancellationToken)
        {
            var userLocation = new Point(request.Longitude, request.Latitude) { SRID = 4326 };
            // Use IDbContextFactory to create a new DbContext instance
            await using var dbContext = _dbContextFactory.CreateDbContext();

            var nearestLocation = await dbContext.Locations
                .FromSqlInterpolated($@"
                    SELECT *, ST_Distance(geom, ST_SetSRID(ST_MakePoint({request.Longitude}, {request.Latitude}), 4326)) AS distance 
                    FROM locations
                    WHERE ST_DWithin(geom, ST_SetSRID(ST_MakePoint({request.Longitude}, {request.Latitude}), 4326),5000)
                    ORDER BY distance 
                    LIMIT 1")
                .Select(l => new LocationDto
                {
                    Id = l.Id,
                    Name = l.Name,
                    Latitude = l.Geom.Y,  // Extract latitude from geometry
                    Longitude = l.Geom.X, // Extract longitude from geometry
                    Address = l.Address,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return nearestLocation;

        }
    }
}
