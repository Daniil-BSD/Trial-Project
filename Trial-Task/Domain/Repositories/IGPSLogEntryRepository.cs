using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Domain.Repositories
{
	public interface IGPSLogEntryRepository
	{
		Task<IEnumerable<GPSLogEntry>> ListAsync(Guid id);
	}
}
