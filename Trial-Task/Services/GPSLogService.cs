using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Repositories;
using Trial_Task.Domain.Services;

namespace Trial_Task.Services
{
    public class GPSLogService : IGPSLogService
    {

        private readonly IGPSLogRepository  _gpsLogRepository;

        public GPSLogService(IGPSLogRepository gpsLogRepository)
        {
			_gpsLogRepository = gpsLogRepository;
        }

        public async Task<IEnumerable<GPSLog>> ListAsync()
        {
            return await _gpsLogRepository.ListAsync();
        }
    }
}
