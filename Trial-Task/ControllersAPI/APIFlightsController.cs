using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.APIInterface;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.RoleManagment;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task_WEB.ControllersAPI
{
	/// <summary>
	/// Defines the <see cref="APIFlightsController" />
	/// </summary>
	[Route("/api/[controller]")]
	public class APIFlightsController : APIBaseController, IAPIFlightsController
	{
		private readonly IFlightService _flightService;

		public APIFlightsController(IFlightService flightService) : base()
		{
			_flightService = flightService;
		}

		[HttpGet("reduced")]
		public async Task<SpecificObjectResult<List<FlightBasicDTO>>> GetAllReducedAsync()
		{
			var flights = await _flightService.ListReducedAsync();
			return new SpecificObjectResult<List<FlightBasicDTO>>(flights);
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

		[HttpGet("GS{id}")]
		public async Task<SpecificObjectResult<FlightBasicDTO>> GetBaisicAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var flight = await _flightService.GetBasicAsync(guid);
				return new SpecificObjectResult<FlightBasicDTO>(flight);
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<FlightBasicDTO>(BadRequest("Invalid id format"));
			}
		}

		[HttpPost("updateStatus")]
		[Authorize(Policy = Policies.ADMINS)]
		public async Task<SpecificObjectResult<FlightBasicDTO>> UpdateStatus([FromBody] FlightStatusUpdateDTO flightStatusUpdateDTO)
		{
			if (!ModelState.IsValid)
				return new SpecificObjectResult<FlightBasicDTO>(BadRequest(INVALID_MODEL_MESSAGE_STRING));
			var response = await _flightService.UpdaateStatus(flightStatusUpdateDTO);
			if (response.Success)
				return new SpecificObjectResult<FlightBasicDTO>(response.Value);
			return new SpecificObjectResult<FlightBasicDTO>(BadRequest(response.Message));
		}

		[HttpPost("upladIGC")]
		[Authorize(Policy = Policies.MEMBERS)]
		public async Task<SpecificObjectResult<FlightDTO>> UploadIGCFile(IFormFile file)
		{
			if (file == null || file.Length == 0)
				return new SpecificObjectResult<FlightDTO>(BadRequest("File not found."));
			if (Path.GetExtension(file.FileName) != ".igc")
				return new SpecificObjectResult<FlightDTO>(BadRequest("File type is not supported."));
			var path = Path.Combine(
						Directory.GetCurrentDirectory(), "wwwroot",
						file.FileName);
			using (var stream = new FileStream(path, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
			var response = await _flightService.ParseIGCFile(path);
			return new SpecificObjectResult<FlightDTO>(response);
		}
	}
}
