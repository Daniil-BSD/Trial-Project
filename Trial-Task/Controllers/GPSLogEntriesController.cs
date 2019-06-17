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
	public class GPSLogEntriesController : BaseController
	{

		private readonly IGPSLogEntryService _gpsLogEntryService;

		public GPSLogEntriesController(IGPSLogEntryService gpsLogEntryService) : base()
		{
			_gpsLogEntryService = gpsLogEntryService;
		}

		[HttpGet("{id}")]
		public async Task<SpecificObjectResult<IEnumerable<GPSLogEntryDTO>>> GetAllAsync(string id)
		{
			try
			{
				Guid guid = new Guid(id);
				var entries = await _gpsLogEntryService.ListAsync(guid);
				return new SpecificObjectResult<IEnumerable<GPSLogEntryDTO>>(entries);
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<IEnumerable<GPSLogEntryDTO>>(BadRequest(INVALID_ID_MESSAGE_STRING));
			}
		}
	}
}
