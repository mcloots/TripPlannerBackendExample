using AutoMapper;
using TripPlannerBackend.API.Dto;
using TripPlannerBackend.DAL.Entity;

namespace TripPlannerBackend.API.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<TripDto, Trip>();
            CreateMap<Trip, TripDto>();
            CreateMap<Activity, ActivityDto>();
            CreateMap<ActivityDto, Activity>();
        }
    }
}
