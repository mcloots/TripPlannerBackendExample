using TripPlannerBackend.DAL.Entity;

namespace TripPlannerBackend.DAL.Initializer
{
    public class DBInitializer
    {
        public static void Initialize(TripPlannerDbContext context)
        {
            context.Database.EnsureCreated();

            // Seed the Trips table with some dummy data
            if (!context.Trips.Any())
            {
                var trips = new Trip[]
                {
                new Trip { Name = "Trip 1" },
                new Trip { Name = "Trip 2" },
                new Trip { Name = "Trip 3" },
                new Trip { Name = "Trip 4" },
                new Trip { Name = "Trip 5" },
               };

                foreach (Trip t in trips)
                {
                    context.Trips.Add(t);
                }

                context.SaveChanges();
            }
        }
    }
}

  