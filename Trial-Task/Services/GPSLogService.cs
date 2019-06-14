using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Repositories;
using Trial_Task.Domain.Services;

namespace Trial_Task.Services
{
	public class GPSLogService : IGPSLogService
	{

		private readonly IGPSLogRepository _gpsLogRepository;

		public GPSLogService(IGPSLogRepository gpsLogRepository)
		{
			_gpsLogRepository = gpsLogRepository;
		}

		public async Task<GPSLog> GetAsync(Guid id)
		{
			return await _gpsLogRepository.GetAsync(id);
		}

		public async Task<GPSLog> GetFullAsync(Guid id)
		{
			return await _gpsLogRepository.GetFullAsync(id);
		}

		public async Task<IEnumerable<GPSLog>> ListAsync()
		{
			return await _gpsLogRepository.ListAsync();
		}

		public async Task<IEnumerable<GPSLog>> ListReducedAsync()
		{

			return await _gpsLogRepository.ListReducedAsync();
		}

		public async Task<IEnumerable<GPSLog>> ListStandaloneAsync()
		{
			return await _gpsLogRepository.ListStandaloneAsync();
		}
	}
}
