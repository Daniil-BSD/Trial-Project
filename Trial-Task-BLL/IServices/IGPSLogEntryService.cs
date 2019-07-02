using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;

namespace Trial_Task_BLL.IServices
{
	/// <summary>
	/// Defines the <see cref="IGPSLogEntryService" />
	/// </summary>
	public interface IGPSLogEntryService
	{
		/// <summary>
		/// The ListAsync
		/// </summary>
		/// <param name="id">The id<see cref="Guid"/></param>
		/// <returns>The <see cref="Task{List{GPSLogEntryDTO}}"/></returns>
		Task<List<GPSLogEntryDTO>> ListAsync(Guid id);
	}
}
