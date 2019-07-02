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
		/// <summary>
		/// The InsertAsync
		/// </summary>
		/// <param name="fileRecordDTO">The fileRecordDTO<see cref="IGCFileRecordDTO"/></param>
		/// <returns>The <see cref="Task{Response{IGCFileRecordDTO}}"/></returns>
		Task<Response<IGCFileRecordDTO>> InsertAsync(IGCFileRecordDTO fileRecordDTO);

		/// <summary>
		/// The InsertAsync
		/// </summary>
		/// <param name="path">The path<see cref="string"/></param>
		/// <returns>The <see cref="Task{Response{IGCFileRecordDTO}}"/></returns>
		Task<Response<IGCFileRecordDTO>> InsertAsync(string path);

		/// <summary>
		/// The ProcessAllFiles
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		Task ProcessAllFiles();
	}
}
