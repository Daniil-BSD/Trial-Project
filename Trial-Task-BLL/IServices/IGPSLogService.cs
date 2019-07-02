using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.Responses;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.IServices
{
	/// <summary>
	/// Defines the <see cref="IGPSLogService" />
	/// </summary>
	public interface IGPSLogService
	{
		/// <summary>
		/// The GetAsync
		/// </summary>
		/// <param name="id">The id<see cref="Guid"/></param>
		/// <returns>The <see cref="Task{Response{GPSLogDTO}}"/></returns>
		Task<Response<GPSLogDTO>> GetAsync(Guid id);

		/// <summary>
		/// The GetFullAsync
		/// </summary>
		/// <param name="id">The id<see cref="Guid"/></param>
		/// <returns>The <see cref="Task{Response{GPSLogStandaloneDTO}}"/></returns>
		Task<Response<GPSLogStandaloneDTO>> GetFullAsync(Guid id);

		/// <summary>
		/// The ListAsync
		/// </summary>
		/// <returns>The <see cref="Task{IEnumerable{GPSLogDTO}}"/></returns>
		Task<IEnumerable<GPSLogDTO>> ListAsync();

		/// <summary>
		/// The ListReducedAsync
		/// </summary>
		/// <returns>The <see cref="Task{IEnumerable{GPSLogBasicDTO}}"/></returns>
		Task<IEnumerable<GPSLogBasicDTO>> ListReducedAsync();

		/// <summary>
		/// The ParseGPSLogEntries
		/// </summary>
		/// <param name="entries">The entries<see cref="List{GPSLogEntry}"/></param>
		/// <returns>The <see cref="Task{GPSLog}"/></returns>
		Task<GPSLog> ParseGPSLogEntries(List<GPSLogEntry> entries);
	}
}
