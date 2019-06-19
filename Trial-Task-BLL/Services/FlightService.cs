using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.Responses;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Services
{
	/// <summary>
	/// Defines the <see cref="FlightService" />
	/// </summary>
	public class FlightService : BaseService, IFlightService
	{
		private readonly IFlightRepository _flightRepository;

		public FlightService(IFlightRepository flightRepository, IMapper mapper, SignInManager<User> signInManager) : base(mapper, signInManager)
		{
			_flightRepository = flightRepository;
		}

		public async Task<Response<FlightDTO>> GetAsync(Guid id)
		{
			var task = _flightRepository.GetAsync(id);
			return await Response<FlightDTO>.CatchInvalidOperationExceptionAndMap(task, _mapper);
		}

		public async Task<IEnumerable<FlightShallowDTO>> ListAsync()
		{
			var flights = await _flightRepository.ListAsync();
			return _mapper.Map<IEnumerable<Flight>, IEnumerable<FlightShallowDTO>>(flights);
		}

		public async Task<IEnumerable<FlightBasicDTO>> ListReducedAsync()
		{
			var flights = await _flightRepository.ListReducedAsync();
			return _mapper.Map<IEnumerable<Flight>, IEnumerable<FlightBasicDTO>>(flights);
		}
	}
}
