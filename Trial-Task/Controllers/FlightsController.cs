using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task_WEB.Controllers
{
	/// <summary>
	/// Defines the <see cref="FlightsController" />
	/// </summary>
	[Route("/api/[controller]")]
	public class FlightsController : BaseController
	{
		private readonly IFlightService _flightService;

		public FlightsController(IFlightService flightService) : base()
		{
			_flightService = flightService;
		}

		[HttpGet]
		public async Task<SpecificObjectResult<IEnumerable<FlightShallowDTO>>> GetAllAsync()
		{
			var flights = await _flightService.ListAsync();
			return new SpecificObjectResult<IEnumerable<FlightShallowDTO>>(flights);
		}

		[HttpGet("reduced")]
		public async Task<SpecificObjectResult<IEnumerable<FlightBasicDTO>>> GetAllReducedAsync()
		{
			var flights = await _flightService.ListReducedAsync();
			return new SpecificObjectResult<IEnumerable<FlightBasicDTO>>(flights);
		}

		[HttpGet("GF{id}")]
		public async Task<SpecificObjectResult<FlightDTO>> GetAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var flight = await _flightService.GetAsync(guid);
				return new SpecificObjectResult<FlightDTO>(flight);
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<FlightDTO>(BadRequest("Invalid id format"));
			}
		}
	}
}
