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
		/// <summary>
		/// Standart Get method for a single <see cref="GPSLog"/>
		/// (Does not include <see cref="Flight"/> Information)
		/// </summary>
		/// <param name="id">The <see cref="Guid"/> id.</param>
		/// <returns>The <see cref="Task{GPSLog}"/></returns>
		Task<GPSLog> GetAsync(Guid id);

		/// <summary>
		/// Get method for a single <see cref="GPSLog"/> with all inclludes for its <see cref="Flight"/>
		/// </summary>
		/// <param name="id">The <see cref="Guid"/> id.</param>
		/// <returns>The <see cref="Task{GPSLog}"/></returns>
		Task<GPSLog> GetFullAsync(Guid id);

		/// <summary>
		/// Lists all the <see cref="GPSLog"/> in the Database. (inclludes <see cref="GPSLogEntry"/> list for each)
		/// </summary>
		/// <returns>The <see cref="Task{List{GPSLog}}"/></returns>
		Task<List<GPSLog>> ListAsync();

		/// <summary>
		/// Lists all the <see cref="GPSLog"/> in the Database ommiting Entries.
		/// </summary>
		/// <returns>The <see cref="Task{List{GPSLog}}"/></returns>
		Task<List<GPSLog>> ListReducedAsync();
	}
}
