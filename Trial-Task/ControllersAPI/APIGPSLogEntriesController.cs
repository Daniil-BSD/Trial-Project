using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task_WEB.ControllersAPI
{
	/// <summary>
	/// Defines the <see cref="APIGPSLogEntriesController" />
	/// </summary>
	[Route("/api/[controller]")]
	public class APIGPSLogEntriesController : APIBaseController
	{
		private readonly IGPSLogEntryService _gpsLogEntryService;

		public APIGPSLogEntriesController(IGPSLogEntryService gpsLogEntryService) : base()
		{
			_gpsLogEntryService = gpsLogEntryService;
		}

		[HttpGet("JSON{id}")]
		public async Task<SpecificObjectResult<List<GPSLogEntryDTO>>> GetJSONAsync(string id)
		{
			try
			{
				Guid guid = new Guid(id);
				var entries = await _gpsLogEntryService.ListAsync(guid);
				return new SpecificObjectResult<List<GPSLogEntryDTO>>(entries);
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<List<GPSLogEntryDTO>>(BadRequest(INVALID_ID_MESSAGE_STRING));
			}
		}


		[HttpGet("D{id}")]
		public async Task<SpecificObjectResult<string>> GetAsStringAsync(string id)
		{
			try
			{
				Guid guid = new Guid(id);
				var entries = await _gpsLogEntryService.ListAsync(guid);
				return new SpecificObjectResult<string>(MapLoocationsLongLatToString(entries));
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<string>(BadRequest(INVALID_ID_MESSAGE_STRING));
			}
		}

		[HttpGet("Arr{id}")]
		public async Task<SpecificObjectResult<List<float[]>>> GetAsArrayAsync(string id)
		{
			try
			{
				Guid guid = new Guid(id);
				var entries = await _gpsLogEntryService.ListAsync(guid);
				return new SpecificObjectResult<List<float[]>>(MapLoocationsLongLat(entries));
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<List<float[]>>(BadRequest(INVALID_ID_MESSAGE_STRING));
			}
		}
		private string MapLoocationsLongLatToString( List<GPSLogEntryDTO> entries)
		{
			//int stride = (Entries.Count / MAX_DISPLAYED_ENTRIES) + 1;
			int stride = 1;
			string ret = "[[" + entries[0].Longitude.ToString().Replace(",", ".") + "," + entries[0].Latitude.ToString().Replace(",", ".") + "]";
			int i;
			for (i = stride ; i < entries.Count ; i += stride)
			{
				ret += ",[" + entries[i].Longitude.ToString().Replace(",", ".") + "," + entries[i].Latitude.ToString().Replace(",", ".") + "]";
			}
			if (i - stride + 1 != entries.Count)
			{
				ret += ",[" + entries[entries.Count - 1].Longitude.ToString().Replace(",", ".") + "," + entries[entries.Count - 1].Latitude.ToString().Replace(",", ".") + "]";
			}
			return ret + "]";
		}

		private List<float[]> MapLoocationsLongLat(List<GPSLogEntryDTO> entries)
		{
			List<float[]> ret = new List<float[]>();
			foreach (var entry in entries) {
				ret.Add(new float[] { (float)entry.Latitude, (float)entry.Longitude});
			}
			return ret;
		}
	}
}
