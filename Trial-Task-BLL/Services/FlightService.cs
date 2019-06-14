using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Services
{
	public class FlightService : BaseService, IFlightService
	{

		private readonly IFlightRepository _flightRepository;

		public FlightService(IFlightRepository flightRepository, IMapper mapper) : base(mapper)
		{
			_flightRepository = flightRepository;
		}

		public async Task<IEnumerable<FlightShallowDTO>> ListAsync()
		{
			var flights = await _flightRepository.ListAsync();
			return _mapper.Map<IEnumerable<Flight>, IEnumerable<FlightShallowDTO>>(flights);
		}

		public async Task<FlightDTO> GetAsync(Guid id)
		{
			var flight = await _flightRepository.GetAsync(id);
			return _mapper.Map<Flight, FlightDTO>(flight);

		}

		public async Task<IEnumerable<FlightBasicDTO>> ListReducedAsync()
		{
			var flights = await _flightRepository.ListReducedAsync();
			return _mapper.Map<IEnumerable<Flight>, IEnumerable<FlightBasicDTO>>(flights);
		}
	}
}
