﻿using System;
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
        public async Task<IEnumerable<FlightDTO>> GetAllAsync()
        {
            var flights = await _flightService.ListAsync();



			var resources = _mapper.Map<IEnumerable<Flight>, IEnumerable<FlightDTO>>(flights);
			return resources;
        }
    }
}
