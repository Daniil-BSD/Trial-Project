using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.Responses;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task_WEB.Controllers
{
	/// <summary>
	/// Defines the <see cref="AirfieldsController" />
	/// </summary>
	[Route("/api/[controller]")]
	public class AirfieldsController : BaseController
	{
		private readonly IAirfieldService _airfieldService;

		public AirfieldsController(IAirfieldService airfieldService) : base()
		{
			_airfieldService = airfieldService;
		}

		[HttpGet]
		public async Task<SpecificObjectResult<IEnumerable<AirfieldShallowDTO>>> GetAllAsync()
		{
			var airfields = await _airfieldService.ListShallowAsync();
			return new SpecificObjectResult<IEnumerable<AirfieldShallowDTO>>(airfields);
		}

		[HttpGet("full")]
		public async Task<SpecificObjectResult<IEnumerable<AirfieldDTO>>> GetAllFullAsync()
		{
			var airfields = await _airfieldService.ListAsync();
			return new SpecificObjectResult<IEnumerable<AirfieldDTO>>(airfields);
		}

		[HttpGet("GF{id}")]
		public async Task<SpecificObjectResult<AirfieldDTO>> GetAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var response = await _airfieldService.GetAsync(guid);
				return new SpecificObjectResult<AirfieldDTO>(response);
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<AirfieldDTO>(BadRequest(INVALID_ID_MESSAGE_STRING));
			}
		}

		[HttpGet("GS{id}")]
		public async Task<SpecificObjectResult<AirfieldShallowDTO>> GetShallowAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var response = await _airfieldService.GetShallowAsync(guid);
				return new SpecificObjectResult<AirfieldShallowDTO>(response);
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<AirfieldShallowDTO>(BadRequest(INVALID_ID_MESSAGE_STRING));
			}
		}

		[HttpPost("addSingle")]
		public async Task<SpecificObjectResult<AirfieldShallowDTO>> PostSingleAsync([FromBody] AirfieldSaveDTO airfieldSaveDTO)
		{
			if (!ModelState.IsValid)
				return new SpecificObjectResult<AirfieldShallowDTO>(BadRequest(INVALID_MODEL_MESSAGE_STRING));
			var response = await _airfieldService.SaveAsync(airfieldSaveDTO);
			if (response.Success)
				return new SpecificObjectResult<AirfieldShallowDTO>(response.Value);
			return new SpecificObjectResult<AirfieldShallowDTO>(BadRequest(response.Message));
		}
		[HttpPost("add")]
		public async Task<SpecificObjectResult<IEnumerable<SpecificObjectResult<AirfieldShallowDTO>>>> PostListAsync([FromBody] IEnumerable<AirfieldSaveDTO> airfieldSaveDTOs)
		{
			if (!ModelState.IsValid)
				return new SpecificObjectResult<IEnumerable<SpecificObjectResult<AirfieldShallowDTO>>>(BadRequest(INVALID_MODEL_MESSAGE_STRING));
			LinkedList< SpecificObjectResult < AirfieldShallowDTO >> saved = new LinkedList<SpecificObjectResult<AirfieldShallowDTO>> ();
			 foreach (var airfield in airfieldSaveDTOs) {
				var response = await _airfieldService.SaveAsync(airfield);
				saved.AddLast(new SpecificObjectResult<AirfieldShallowDTO>(response));
			}
			return new SpecificObjectResult<IEnumerable<SpecificObjectResult<AirfieldShallowDTO>>>(saved);
		}
	}
}
