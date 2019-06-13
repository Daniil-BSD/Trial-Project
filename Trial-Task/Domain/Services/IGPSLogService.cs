using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Domain.Services
{
	public interface IGPSLogService
	{
		Task<IEnumerable<GPSLog>> ListAsync();
	}
}
