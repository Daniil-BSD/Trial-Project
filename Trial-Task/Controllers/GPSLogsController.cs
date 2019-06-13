using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Services;

namespace Trial_Task.Controllers
{
	[Route("/api/[controller]")]
	public class GPSLogsController : Controller
	{

		private readonly IGPSLogService _gpsLogService;

		public GPSLogsController(IGPSLogService gpsLogService)
		{
			_gpsLogService = gpsLogService;
		}

		[HttpGet]
		public async Task<IEnumerable<GPSLog>> GetAllAsync()
		{
			var logs = await _gpsLogService.ListAsync();
			return logs;
		}
	}
}
