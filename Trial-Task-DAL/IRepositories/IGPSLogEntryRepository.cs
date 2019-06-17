using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	/// <summary>
	/// Defines the <see cref="IGPSLogEntryRepository" />
	/// </summary>
	public interface IGPSLogEntryRepository
	{
		Task<IEnumerable<GPSLogEntry>> ListAsync(Guid id);
	}
}
