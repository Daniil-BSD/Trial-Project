using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;

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
		public async Task<IEnumerable<AirfieldShallowDTO>> GetAllAsync()
		{
			var airfields = await _airfieldService.ListShallowAsync();
			return airfields;
		}
		[HttpGet("full")]
		public async Task<IEnumerable<AirfieldDTO>> GetAllFullAsync()
		{
			var airfields = await _airfieldService.ListAsync();
			return airfields;
		}

		[HttpGet("GF{id}")]
		public async Task<AirfieldDTO> GetAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var airfield = await _airfieldService.GetAsync(guid); ;
				return airfield;
			}
			catch (FormatException)
			{
				return null;
			}
		}

		[HttpGet("GS{id}")]
		public async Task<AirfieldShallowDTO> GetShallowAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var airfield = await _airfieldService.GetShallowAsync(guid);
				return airfield;
			}
			catch (FormatException)
			{
				return null;
			}
		}
	}
}
