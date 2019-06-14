using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	public interface IGPSLogEntryRepository
	{
		Task<IEnumerable<GPSLogEntry>> ListAsync(Guid id);
	}
}
