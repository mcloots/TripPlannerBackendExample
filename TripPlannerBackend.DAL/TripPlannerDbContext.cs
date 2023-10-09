using Microsoft.EntityFrameworkCore;
using TripPlannerBackend.DAL.Entity;

namespace TripPlannerBackend.DAL
{
    public class TripPlannerDbContext : DbContext
    {
        public TripPlannerDbContext()
        {

        }

        public TripPlannerDbContext(DbContextOptions<TripPlannerDbContext> options) : base(options)
        {
        }
        public DbSet<Trip> Trips => Set<Trip>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().ToTable("Trip");
        }
    }
}