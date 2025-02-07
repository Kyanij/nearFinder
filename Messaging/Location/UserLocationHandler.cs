using MediatR;
using Microsoft.EntityFrameworkCore;
using NearFinder.Persistance;

namespace NearFinder.Messaging.Location
{
    public class UserLocationHandler : IRequestHandler<UserLocationInput>
    {
        private readonly NearFinderDbContext _context;

        public UserLocationHandler(NearFinderDbContext dbcontext)
        {
            this._context = dbcontext;
        }
        public async Task Handle(UserLocationInput request, CancellationToken cancellationToken)
        {
            //var nearestLocation = await _context.Location
            //                            .OrderBy(l => EF.ST_Distance)
        }
    }
}
