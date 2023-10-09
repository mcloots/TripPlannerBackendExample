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
        public DbSet<Activity> Activities => Set<Activity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>()
               .HasMany(e => e.Activities)
               .WithOne(e => e.Trip)
               .HasForeignKey(e => e.TripId)
               .IsRequired();

            //Other side
            //modelBuilder.Entity<Activity>()
            //    .HasOne(e => e.Trip)
            //    .WithMany(e => e.Activities)
            //    .HasForeignKey(e => e.TripId)
            //    .IsRequired();

            modelBuilder.Entity<Trip>().ToTable("Trip");
            modelBuilder.Entity<Activity>().ToTable("Activity");
        }
    }
}