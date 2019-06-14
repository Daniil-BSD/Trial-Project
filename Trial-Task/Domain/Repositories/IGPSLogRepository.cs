using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Domain.Repositories
{
	public interface IGPSLogRepository
	{
		Task<IEnumerable<GPSLog>> ListReducedAsync();
		Task<IEnumerable<GPSLog>> ListStandaloneAsync();
		Task<IEnumerable<GPSLog>> ListAsync();
		Task<GPSLog> GetAsync(Guid id);
		Task<GPSLog> GetFullAsync(Guid id);
	}
}
