using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.Responses;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task_WEB.ControllersAPI
{
	/// <summary>
	/// Defines the <see cref="APIAirfieldsController" />
	/// </summary>
	[Route("/api/[controller]")]
	public class APIAirfieldsController : APIBaseController
	{
		private readonly IAirfieldService _airfieldService;

		public APIAirfieldsController(IAirfieldService airfieldService) : base()
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

		[HttpPost("add")]
		public async Task<SpecificObjectResultList<AirfieldShallowDTO>> PostListAsync([FromBody] IEnumerable<AirfieldSaveDTO> airfieldSaveDTOs)
		{
			if (!ModelState.IsValid)
				return new SpecificObjectResultList<AirfieldShallowDTO>(BadRequest(INVALID_MODEL_MESSAGE_STRING));
			List<Response<AirfieldShallowDTO>> responses = new List<Response<AirfieldShallowDTO>>();
			foreach (var airfield in airfieldSaveDTOs)
			{
				responses.Add(await _airfieldService.SaveAsync(airfield));
			}
			return new SpecificObjectResultList<AirfieldShallowDTO>(responses);
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

		[HttpPost("upladXLSX")]
		public async Task<SpecificObjectResultList<AirfieldShallowDTO>> UploadXLSXFile(IFormFile file)
		{
			if (file == null || file.Length == 0)
				return new SpecificObjectResultList<AirfieldShallowDTO>(BadRequest("File not found."));
			if (Path.GetExtension(file.FileName) != ".xlsx")
				return new SpecificObjectResultList<AirfieldShallowDTO>(BadRequest("File type is not supported."));
			var path = Path.Combine(
						Directory.GetCurrentDirectory(), "wwwroot",
						file.FileName);
			using (var stream = new FileStream(path, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
			var responses = await _airfieldService.ParseXLSXFile(path);
			return new SpecificObjectResultList<AirfieldShallowDTO>(responses);
		}
	}
}
