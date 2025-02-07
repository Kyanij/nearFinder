using Microsoft.EntityFrameworkCore;

namespace NearFinder.Persistance
{
    public class NearFinderDbContext : DbContext
    {
        /// <summary>
        /// Location
        /// </summary>
        public DbSet<Location> Location { get; private set; } = null!;

        public NearFinderDbContext(DbContextOptions<NearFinderDbContext> options) : base(options) { }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NearFinderDbContext).Assembly);
        }
        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
            base.OnConfiguring(optionsBuilder);
        }

    }
}
