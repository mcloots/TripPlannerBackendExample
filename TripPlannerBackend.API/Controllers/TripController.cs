﻿using AutoMapper;
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
        //[Authorize]
        //[Authorize(Policy = "TripReadAccess")]
        public async Task<ActionResult<GetTripDto>> GetTrip(int id)
        {
            var trip = await _context.Trips.Include(t => t.Activities).SingleAsync(t => t.Id == id);

            if (trip == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetTripDto>(trip);
        }

        //Get Search
        [HttpGet]
        //[Authorize]
        //[Authorize(Policy = "TripReadAccess")]
        public ActionResult<List<GetTripDto>> SearchTrip([FromQuery]SearchTripDto searchDto)
        {
            var trips = _context.Trips.Include(t => t.Activities).Where(t => 
            t.Name.ToLower().Contains(searchDto.Name.ToLower()));

            if (trips == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetTripDto>>(trips);
        }

        //Insert - you have to be authenticated
        [HttpPost]
        //[Authorize]
        //[Authorize(Policy = "TripWriteAccess")]
        public async Task<ActionResult<GetTripDto>> AddTrip(CreateTripDto trip)
        {
            //We map the CreateTripDto to the Trip entity object
            Trip tripToAdd = _mapper.Map<Trip>(trip);
            _context.Trips.Add(tripToAdd);
            await _context.SaveChangesAsync();
            GetTripDto tripToReturn = _mapper.Map<GetTripDto>(tripToAdd);

            return CreatedAtAction(nameof(GetTrip), new { id = tripToReturn.Id }, tripToReturn);
        }
    }
}
