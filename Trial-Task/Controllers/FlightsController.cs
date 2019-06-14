using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;

namespace Trial_Task_WEB.Controllers
{
	[Route("/api/[controller]")]
	public class FlightsController : BaseController
	{

		private readonly IFlightService _flightService;

		public FlightsController(IFlightService flightService) : base()
		{
			_flightService = flightService;
		}

		[HttpGet]
		public async Task<IEnumerable<FlightShallowDTO>> GetAllAsync()
		{
			var flights = await _flightService.ListAsync();
			return flights;
		}
		[HttpGet("reduced")]
		public async Task<IEnumerable<FlightBasicDTO>> GetAllReducedAsync()
		{
			var flights = await _flightService.ListReducedAsync();
			return flights;
		}

		[HttpGet("GF{id}")]
		public async Task<FlightDTO> GetAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var flight = await _flightService.GetAsync(guid);
				return flight;
			}
			catch (FormatException)
			{
				//return NotFound();
				return null;
			}
		}
	}
}
