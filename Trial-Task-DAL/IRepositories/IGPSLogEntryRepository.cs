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
		/// <summary>
		/// Lists all the Entries In the Database with a specified LogID.
		/// </summary>
		/// <param name="id">The <see cref="Guid"/> id of the <see cref="GPSLog"/> requested entries belong to.</param>
		/// <returns>The <see cref="Task{List{GPSLogEntry}}"/></returns>
		Task<List<GPSLogEntry>> ListAsync(Guid id);
	}
}
