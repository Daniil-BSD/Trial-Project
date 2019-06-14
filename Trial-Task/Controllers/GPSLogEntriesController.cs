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
	public class GPSLogEntriesController : BaseController
	{

		private readonly IGPSLogEntryService _gpsLogEntryService;

		public GPSLogEntriesController(IGPSLogEntryService gpsLogEntryService, IMapper mapper) : base(mapper)
		{
			_gpsLogEntryService = gpsLogEntryService;
		}

		[HttpGet("{id}")]
		public async Task<IEnumerable<GPSLogEntryDTO>> GetAllAsync(string id)
		{
			try
			{
				Guid guid = new Guid(id);
				var entries = await _gpsLogEntryService.ListAsync(guid);
				var resources = _mapper.Map<IEnumerable<GPSLogEntry>, IEnumerable<GPSLogEntryDTO>>(entries);
				return resources;
			}
			catch (FormatException)
			{
				return null;
			}
		}
	}
}
