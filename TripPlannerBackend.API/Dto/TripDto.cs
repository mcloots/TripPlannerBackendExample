namespace TripPlannerBackend.API.Dto
{
    public class TripDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ActivityDto> Activities { get; set; }
    }
}
