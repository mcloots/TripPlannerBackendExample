namespace TripPlannerBackend.API.Dto
{
    public class GetTripDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<GetActivityDto> Activities { get; set; }
    }
}
