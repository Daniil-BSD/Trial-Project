using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Domain.Services
{
	public interface IGPSLogEntryService
	{
		Task<IEnumerable<GPSLogEntry>> ListAsync(Guid id);
	}
}
