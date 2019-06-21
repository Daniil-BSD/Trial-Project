using System;
using System.Threading.Tasks;
using Trial_Task_Model.Interfaces;

namespace Trial_Task_DAL.IRepositories
{
	/// <summary>
	/// Defines the <see cref="IRepositoryForGuiDIdentifyables{T}" />
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepositoryForGuiDIdentifyables<T> where T : IGuidIdentifyable
	{
		Task<T> GetRowAsync(Guid id);
	}
}
