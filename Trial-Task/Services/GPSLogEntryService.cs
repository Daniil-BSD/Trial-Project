using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Repositories;
using Trial_Task.Domain.Services;

namespace Trial_Task.Services
{
	public class GPSLogEntryService : IGPSLogEntryService
	{

		private readonly IGPSLogEntryRepository _gpsLogEntryRepository;

		public GPSLogEntryService(IGPSLogEntryRepository gpsLogEntryRepository)
		{
			_gpsLogEntryRepository = gpsLogEntryRepository;
		}

		public async Task<IEnumerable<GPSLogEntry>> ListAsync(Guid id)
		{
			return await _gpsLogEntryRepository.ListAsync(id);
		}
	}
}
