using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.Responses;

namespace Trial_Task_BLL.IServices
{
	/// <summary>
	/// Defines the <see cref="IIGCFileRecordService" />
	/// </summary>
	public interface IIGCFileRecordService
	{
		Task<Response<IGCFileRecordDTO>> InsertAsync(IGCFileRecordDTO fileRecordDTO);

		Task<Response<IGCFileRecordDTO>> InsertAsync(string path);

		Task ProcessAllFiles();
	}
}
