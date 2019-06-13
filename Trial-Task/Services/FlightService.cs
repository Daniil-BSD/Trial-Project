using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Repositories;
using Trial_Task.Domain.Services;

namespace Trial_Task.Services
{
    public class FlightService : IFlightService
    {

        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
			_flightRepository = flightRepository;
        }

        public async Task<IEnumerable<Flight>> ListAsync()
        {
            return await _flightRepository.ListAsync();
        }
    }
}
