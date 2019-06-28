using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.Responses;
using Trial_Task_DAL.IRepositories;
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

		public async Task<IEnumerable<GPSLogStandaloneListDTO>> ListStandaloneAsync()
		{
			var logs = await _gpsLogRepository.ListStandaloneAsync();
			return _mapper.Map<IEnumerable<GPSLog>, IEnumerable<GPSLogStandaloneListDTO>>(logs);
		}

		public async Task<GPSLog> ParseGPSLogEntries(List<GPSLogEntry> entries)
		{
			var takeoff = await _airfieldService.GetLocalAirfieldID(entries[0]);
			var landing = await _airfieldService.GetLocalAirfieldID(entries[entries.Count - 1]);
			GPSLog ret = new GPSLog()
			{
				Entries = entries,
				Duration = new TimeSpan(entries[entries.Count - 1].Time.Ticks - entries[0].Time.Ticks),
				TakeoffID = (takeoff.Success) ? takeoff.Value : (Guid?)null,
				LandingID = (landing.Success) ? landing.Value : (Guid?)null,
			};
			return ret;
		}
	}
}
