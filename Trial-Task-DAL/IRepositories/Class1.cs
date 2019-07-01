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
		Task DeleteAsync(IGCFileRecord fileRecord, bool saveChanges = true);

		Task<List<IGCFileRecord>> GetListOfFiles();

		Task<IGCFileRecord> InsertAsync(IGCFileRecord fileRecord);
	}
}
