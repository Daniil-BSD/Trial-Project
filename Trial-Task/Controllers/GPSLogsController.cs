using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;

namespace Trial_Task_WEB.Controllers
{
	[Route("/api/[controller]")]
	public class GPSLogsController : BaseController
	{

		private readonly IGPSLogService _gpsLogService;

		public GPSLogsController(IGPSLogService gpsLogService) : base()
		{
			_gpsLogService = gpsLogService;
		}

		[HttpGet]
		public async Task<IEnumerable<GPSLogBasicDTO>> GetAllAsync()
		{
			var logs = await _gpsLogService.ListReducedAsync();
			return logs;
		}

		[HttpGet("full")]
		public async Task<IEnumerable<GPSLogStandaloneListDTO>> GetAllFullAsync()
		{
			var logs = await _gpsLogService.ListStandaloneAsync();
			return logs;
		}

		[HttpGet("GS{id}")]
		public async Task<GPSLogDTO> GetAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var log = await _gpsLogService.GetAsync(guid);
				return log;
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
				return log;
			}
			catch (FormatException)
			{
				return null;
			}
		}
	}
}
