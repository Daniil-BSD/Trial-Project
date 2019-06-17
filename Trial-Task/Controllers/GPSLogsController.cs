using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task_WEB.Controllers
{
	/// <summary>
	/// Defines the <see cref="GPSLogsController" />
	/// </summary>
	[Route("/api/[controller]")]
	public class GPSLogsController : BaseController
	{
		private readonly IGPSLogService _gpsLogService;

		public GPSLogsController(IGPSLogService gpsLogService) : base()
		{
			_gpsLogService = gpsLogService;
		}

		[HttpGet]
		public async Task<SpecificObjectResult<IEnumerable<GPSLogBasicDTO>>> GetAllAsync()
		{
			var logs = await _gpsLogService.ListReducedAsync();
			return new SpecificObjectResult<IEnumerable<GPSLogBasicDTO>>(logs);
		}

		[HttpGet("full")]
		public async Task<SpecificObjectResult<IEnumerable<GPSLogStandaloneListDTO>>> GetAllFullAsync()
		{
			var logs = await _gpsLogService.ListStandaloneAsync();
			return new SpecificObjectResult<IEnumerable<GPSLogStandaloneListDTO>>(logs);
		}

		[HttpGet("GS{id}")]
		public async Task<SpecificObjectResult<GPSLogDTO>> GetAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var log = await _gpsLogService.GetAsync(guid);
				return new SpecificObjectResult<GPSLogDTO>(log);
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<GPSLogDTO>(BadRequest(INVALID_ID_MESSAGE_STRING));
			}
		}

		[HttpGet("GF{id}")]
		public async Task<SpecificObjectResult<GPSLogStandaloneDTO>> GetFullAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var log = await _gpsLogService.GetFullAsync(guid);
				return new SpecificObjectResult<GPSLogStandaloneDTO>(log);
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<GPSLogStandaloneDTO>(BadRequest(INVALID_ID_MESSAGE_STRING));
			}
		}
	}
}
