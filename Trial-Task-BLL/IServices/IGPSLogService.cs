using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;

namespace Trial_Task_BLL.IServices
{
	/// <summary>
	/// Defines the <see cref="IGPSLogService" />
	/// </summary>
	public interface IGPSLogService
	{
		Task<GPSLogDTO> GetAsync(Guid id);

		Task<GPSLogStandaloneDTO> GetFullAsync(Guid id);

		Task<IEnumerable<GPSLogDTO>> ListAsync();

		Task<IEnumerable<GPSLogBasicDTO>> ListReducedAsync();

		Task<IEnumerable<GPSLogStandaloneListDTO>> ListStandaloneAsync();
	}
}
