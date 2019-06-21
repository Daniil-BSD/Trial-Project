using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	/// <summary>
	/// Defines the <see cref="IGPSLogRepository" />
	/// </summary>
	public interface IGPSLogRepository : IRepositoryForGuiDIdentifyables<GPSLog>
	{
		Task<GPSLog> GetAsync(Guid id);

		Task<GPSLog> GetFullAsync(Guid id);

		Task<List<GPSLog>> ListAsync();

		Task<List<GPSLog>> ListReducedAsync();

		Task<List<GPSLog>> ListStandaloneAsync();
	}
}
