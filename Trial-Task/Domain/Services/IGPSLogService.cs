using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Domain.Services
{
	public interface IGPSLogService
	{
		Task<IEnumerable<GPSLog>> ListAsync();
		Task<IEnumerable<GPSLog>> ListReducedAsync();
		Task<IEnumerable<GPSLog>> ListStandaloneAsync();
		Task<GPSLog> GetAsync(Guid id);
		Task<GPSLog> GetFullAsync(Guid id);
	}
}
