using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripPlannerBackend.API.Dto;
using TripPlannerBackend.DAL;
using TripPlannerBackend.DAL.Entity;

namespace TripPlannerBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly TripPlannerDbContext _context;
        private readonly IMapper _mapper;
        public TripController(TripPlannerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Search - everyone is allowed to search

        //Get By ID
        [HttpGet("{id}")]
        [Authorize]
        //[Authorize(Policy = "TripReadAccess")]
        public async Task<ActionResult<TripDto>> GetTrip(int id)
        {
            var trip = await _context.Trips.Include(t => t.Activities).SingleAsync(t => t.Id == id);

            if (trip == null)
            {
                return NotFound();
            }

            return _mapper.Map<TripDto>(trip);
        }


        //Insert - you have to be authenticated
        [HttpPost]
        //[Authorize]
        //[Authorize(Policy = "TripWriteAccess")]
        public async Task<ActionResult<TripDto>> PostTrip(TripDto trip)
        {
            //We map the AddTripDto to the Trip entity object
            Trip tripToAdd = _mapper.Map<Trip>(trip);
            _context.Trips.Add(tripToAdd);
            await _context.SaveChangesAsync();
            TripDto tripToReturn = _mapper.Map<TripDto>(tripToAdd);

            return CreatedAtAction(nameof(GetTrip), new { id = tripToReturn.Id }, tripToReturn);
        }
    }
}
