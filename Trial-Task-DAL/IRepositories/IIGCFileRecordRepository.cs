using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.Repositories
{
	/// <summary>
	/// Defines the <see cref="IIGCFileRecordRepository" />
	/// </summary>
	public interface IIGCFileRecordRepository
	{
		/// <summary>
		/// Deletes the record, has a control if the changes have to be applied
		/// </summary>
		/// <param name="fileRecord">The fileRecord <see cref="IGCFileRecord"/> that is to be removed</param>
		/// <param name="saveChanges">The saveChanges<see cref="bool"/> determines if the SacveChanges will be called (useful for batch deletion)</param>
		/// <returns>The <see cref="Task"/></returns>
		Task DeleteAsync(IGCFileRecord fileRecord, bool saveChanges = true);

		/// <summary>
		/// Returns the list of all inptocessed files.
		/// </summary>
		/// <returns>The <see cref="Task{List{IGCFileRecord}}"/></returns>
		Task<List<IGCFileRecord>> GetListOfFiles();

		/// <summary>
		/// Inserts an entry into the database.
		/// </summary>
		/// <param name="fileRecord">The fileRecord<see cref="IGCFileRecord"/></param>
		/// <returns>The <see cref="Task{IGCFileRecord}"/> of the newly added record.</returns>
		Task<IGCFileRecord> InsertAsync(IGCFileRecord fileRecord);
	}
}
