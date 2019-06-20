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

		private readonly IGPSLogService _gpsLogService;

		private readonly IUserService _userService;

		public FlightService(IFlightRepository flightRepository, IGPSLogService gpsLogService, IUserService userService, IMapper mapper, SignInManager<User> signInManager) : base(mapper, signInManager)
		{
			_gpsLogService = gpsLogService;
			_flightRepository = flightRepository;
			_userService = userService;
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

		public async Task<Response<FlightDTO>> ParseIGCFile(string path)
		{

			var userIDResponse = _userService.GetCurrentUserID();
			if (!userIDResponse.Success)
				return new Response<FlightDTO>(userIDResponse);
			List<GPSLogEntry> entries = GPSLogEntry.ParseFixRecords(System.IO.File.ReadAllLines(path));
			Flight flight = new Flight()
			{
				Log = await _gpsLogService.ParseGPSLogEntries(entries),
				Status = Trial_Task_Model.Enumerations.EFlightStatus.Pending,
				UserID = userIDResponse.Value,
				Date = DateTime.Now
			};
			return await Response<FlightDTO>.CatchInvalidOperationExceptionAndMap(_flightRepository.InsertNewFlight(flight), _mapper);
		}
	}
}
