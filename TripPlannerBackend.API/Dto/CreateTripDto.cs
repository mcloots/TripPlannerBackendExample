namespace TripPlannerBackend.API.Dto
{
    public class CreateTripDto
    {
        public string Name { get; set; }

        public IEnumerable<CreateActivityDto> Activities { get; set; }
    }
}
