using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Services;

namespace Trial_Task.Controllers
{
    [Route("/api/[controller]")]
    public class FlightsController : Controller
    {

        private readonly IFlightService _flightService;

        public FlightsController (IFlightService flightService)
        {
			_flightService = flightService;
        }

        [HttpGet]
        public async Task<IEnumerable<Flight>> GetAllAsync()
        {
            var flights = await _flightService.ListAsync();
            return flights;
        }
    }
}
