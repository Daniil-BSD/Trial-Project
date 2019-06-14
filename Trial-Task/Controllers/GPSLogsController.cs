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
	public class GPSLogsController : BaseController
	{

		private readonly IGPSLogService _gpsLogService;

		public GPSLogsController(IGPSLogService gpsLogService, IMapper mapper) : base(mapper)
		{
			_gpsLogService = gpsLogService;
		}

		[HttpGet]
		public async Task<IEnumerable<GPSLogBasicDTO>> GetAllAsync()
		{
			var logs = await _gpsLogService.ListReducedAsync();
			var resources = _mapper.Map<IEnumerable<GPSLog>, IEnumerable<GPSLogBasicDTO>>(logs);
			return resources;
		}

		[HttpGet("full")]
		public async Task<IEnumerable<GPSLogStandaloneListDTO>> GetAllFullAsync()
		{
			var logs = await _gpsLogService.ListStandaloneAsync();
			var resources = _mapper.Map<IEnumerable<GPSLog>, IEnumerable<GPSLogStandaloneListDTO>>(logs);
			return resources;
		}

		[HttpGet("GS{id}")]
		public async Task<GPSLogDTO> GetAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var log = await _gpsLogService.GetAsync(guid);
				var resource = _mapper.Map<GPSLog, GPSLogDTO>(log);
				return resource;
			}
			catch (FormatException)
			{
				return null;
			}
		}

		[HttpGet("GF{id}")]
		public async Task<GPSLogStandaloneDTO> GetFullAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var log = await _gpsLogService.GetFullAsync(guid);
				var resource = _mapper.Map<GPSLog, GPSLogStandaloneDTO>(log);
				return resource;
			}
			catch (FormatException)
			{
				return null;
			}
		}
	}
}
