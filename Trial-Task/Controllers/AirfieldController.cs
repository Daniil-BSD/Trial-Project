using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task_WEB.Controllers
{
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
			return new SpecificObjectResult < IEnumerable < AirfieldShallowDTO >> (airfields);
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
				var airfield = await _airfieldService.GetAsync(guid); ;
				return new SpecificObjectResult<AirfieldDTO>(airfield);
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<AirfieldDTO>(BadRequest("Invalid id format"));
			}
		}

		[HttpGet("GS{id}")]
		public async Task<SpecificObjectResult<AirfieldShallowDTO>> GetShallowAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var airfield = await _airfieldService.GetShallowAsync(guid);
				return new SpecificObjectResult<AirfieldShallowDTO>(airfield);
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<AirfieldShallowDTO>(BadRequest("Invalid id format"));
			}
		}

		[HttpPost("addSingle")]
		public async Task<SpecificObjectResult<AirfieldShallowDTO>> PostSingleAsync([FromBody] AirfieldSaveDTO airfieldSaveDTO) {
			if (!ModelState.IsValid)
				return new SpecificObjectResult<AirfieldShallowDTO>(BadRequest("Invalid Input"));
			var response = await _airfieldService.SaveAsync(airfieldSaveDTO);
			if(response.Success)
				return new SpecificObjectResult<AirfieldShallowDTO>(response.AirfieldDTO);
			return new SpecificObjectResult<AirfieldShallowDTO>(BadRequest(response.Message));
		}
	}
}
