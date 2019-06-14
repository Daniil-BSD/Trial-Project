using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
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
