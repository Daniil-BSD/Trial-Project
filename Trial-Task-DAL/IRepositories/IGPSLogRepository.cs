using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	public interface IGPSLogRepository
	{
		Task<List<GPSLog>> ListReducedAsync();
		Task<List<GPSLog>> ListStandaloneAsync();
		Task<List<GPSLog>> ListAsync();
		Task<GPSLog> GetAsync(Guid id);
		Task<GPSLog> GetFullAsync(Guid id);
	}
}
