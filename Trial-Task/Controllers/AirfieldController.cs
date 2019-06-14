using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Services;
using Trial_Task.DTOs;

namespace Trial_Task.Controllers
{
	[Route("/api/[controller]")]
	public class AirfieldsController : BaseController
	{

		private readonly IAirfieldService _airfieldService;

		public AirfieldsController(IAirfieldService airfieldService, IMapper mapper) : base(mapper)
		{
			_airfieldService = airfieldService;
		}

		[HttpGet]
		public async Task<IEnumerable<AirfieldShallowDTO>> GetAllAsync()
		{
			var airfields = await _airfieldService.ListAsync();
			var resources = _mapper.Map<IEnumerable<Airfield>, IEnumerable<AirfieldShallowDTO>>(airfields);
			return resources;
		}
		[HttpGet("full")]
		public async Task<IEnumerable<AirfieldDTO>> GetAllFullAsync()
		{
			var airfields = await _airfieldService.ListAsync();
			var resources = _mapper.Map<IEnumerable<Airfield>, IEnumerable<AirfieldDTO>>(airfields);
			return resources;
		}

		[HttpGet("GF{id}")]
		public async Task<AirfieldDTO> GetAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var airfields = await _airfieldService.GetAsync(guid);
				var resource = _mapper.Map<Airfield, AirfieldDTO>(airfields);
				return resource;
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
				var airfields = await _airfieldService.GetShallowAsync(guid);
				var resource = _mapper.Map<Airfield, AirfieldShallowDTO>(airfields);
				return resource;
			}
			catch (FormatException)
			{
				return null;
			}
		}
	}
}
