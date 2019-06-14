using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;

namespace Trial_Task_BLL.IServices
{
	public interface IGPSLogEntryService
	{
		Task<IEnumerable<GPSLogEntryDTO>> ListAsync(Guid id);
	}
}
