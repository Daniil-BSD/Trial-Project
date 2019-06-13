using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Services;
using Trial_Task.DTOs;

namespace Trial_Task.Controllers
{
    [Route("/api/[controller]")]
    public class FlightsController : BaseController
	{

        private readonly IFlightService _flightService;

        public FlightsController (IFlightService flightService, IMapper mapper) : base(mapper)
		{
			_flightService = flightService;
        }

        [HttpGet]
        public async Task<IEnumerable<FlightShallowDTO>> GetAllAsync()
        {
            var flights = await _flightService.ListAsync();
			var resources = _mapper.Map<IEnumerable<Flight>, IEnumerable<FlightShallowDTO>>(flights);
			return resources;
        }
		[HttpGet("reduced")]
		public async Task<IEnumerable<FlightBasicDTO>> GetAllReducedAsync()
		{
			var flights = await _flightService.ListReducedAsync();
			var resources = _mapper.Map<IEnumerable<Flight>, IEnumerable<FlightBasicDTO>>(flights);
			return resources;
		}

		[HttpGet("GF{id}")]
		public async Task<FlightDTO> GetAsync(string id)
		{
			var guid = new Guid(id);
			var flight = await _flightService.GetAsync(guid);
			var resource = _mapper.Map<Flight, FlightDTO>(flight);
			return resource;
		}
	}
}
