using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.Responses;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model;
using Trial_Task_Model.Interfaces;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Services
{
	/// <summary>
	/// Defines the <see cref="GPSLogService" />
	/// </summary>
	public class GPSLogService : BaseService, IGPSLogService
	{
		private readonly IAirfieldService _airfieldService;

		private readonly IGPSLogRepository _gpsLogRepository;

		public GPSLogService(IGPSLogRepository gpsLogRepository, IAirfieldService airfieldService, IMapper mapper) : base(mapper)
		{
			_gpsLogRepository = gpsLogRepository;
			_airfieldService = airfieldService;
		}

		public async Task<Response<GPSLogDTO>> GetAsync(Guid id)
		{
			var task = _gpsLogRepository.GetAsync(id);
			return await Response<GPSLogDTO>.CatchInvalidOperationExceptionAndMap(task, _mapper);
		}

		public async Task<Response<GPSLogStandaloneDTO>> GetFullAsync(Guid id)
		{
			var task = _gpsLogRepository.GetFullAsync(id);
			return await Response<GPSLogStandaloneDTO>.CatchInvalidOperationExceptionAndMap(task, _mapper);
		}

		public async Task<IEnumerable<GPSLogDTO>> ListAsync()
		{
			var logs = await _gpsLogRepository.ListAsync();
			return _mapper.Map<IEnumerable<GPSLog>, IEnumerable<GPSLogDTO>>(logs);
		}

		public async Task<IEnumerable<GPSLogBasicDTO>> ListReducedAsync()
		{
			var logs = await _gpsLogRepository.ListReducedAsync();
			return _mapper.Map<IEnumerable<GPSLog>, IEnumerable<GPSLogBasicDTO>>(logs);
		}

		public async Task<GPSLog> ParseGPSLogEntries(List<GPSLogEntry> entries)
		{
			var takeoff = await _airfieldService.GetLocalAirfieldID(entries[0]);
			var landing = await _airfieldService.GetLocalAirfieldID(entries[entries.Count - 1]);
			GPSLog ret = new GPSLog()
			{
				Entries = entries,
				Duration = ComputeDuration(entries),
				TakeoffID = (takeoff.Success) ? takeoff.Value : (Guid?)null,
				LandingID = (landing.Success) ? landing.Value : (Guid?)null,
				ApproxLength = ComputeLength(entries, true),
				RegisteredLength = ComputeLength(entries)
			};
			return ret;
		}

		private TimeSpan ComputeDuration(List<GPSLogEntry> entries)
		{
			int start = -1;
			int end = -1;
			for (int i = 0 ; i < entries.Count - 1 ; i++)
			{
				if (Constants.MIN_SPEED <= GlobalPoint.Distance(entries[i + 1], entries[i]) / ((double)(entries[i + 1].Time.Ticks - entries[i].Time.Ticks) / TimeSpan.TicksPerSecond))
				{
					start = i;
					break;
				}
			}
			for (int i = entries.Count - 1 ; i > 0 ; i--)
			{
				if (Constants.MIN_SPEED <= GlobalPoint.Distance(entries[i - 1], entries[i]) / ((double)(entries[i].Time.Ticks - entries[i - 1].Time.Ticks) / TimeSpan.TicksPerSecond))
				{
					end = i;
					break;
				}
			}
			if (start < end && start != -1)
			{
				new TimeSpan(entries[end].Time.Ticks - entries[start].Time.Ticks);
			}
			return new TimeSpan(entries[entries.Count - 1].Time.Ticks - entries[0].Time.Ticks);
		}

		private double ComputeLength(List<GPSLogEntry> entries, bool approximate = false)
		{
			GPSLogEntry prev = null;
			double ret = 0;
			foreach (var entry in entries)
			{
				if (!approximate || entry.ApproximatingFix)
				{
					if (prev != null)
					{
						ret += GlobalPoint.Distance(prev, entry);
					}
					prev = entry;
				}
			}
			return ret;
		}
	}
}
