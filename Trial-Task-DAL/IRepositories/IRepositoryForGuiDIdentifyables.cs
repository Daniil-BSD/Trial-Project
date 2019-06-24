using System;
using System.Threading.Tasks;
using Trial_Task_Model.Interfaces;

namespace Trial_Task_DAL.IRepositories
{
	/// <summary>
	/// Interface for Repositories of classes that implement <see cref="IGuidIdentifyable"/>
	/// </summary>
	/// <typeparam name="T">The <see cref="IGuidIdentifyable"/> class that this repositry manages.</typeparam>
	public interface IRepositoryForGuiDIdentifyables<T> where T : IGuidIdentifyable
	{
		/// <summary>
		/// The GetRowAsync is a generic method for getting only table data of a specific element without unesesary includes.
		/// </summary>
		/// <param name="id">The <see cref="Guid"/ id of the requested element.></param>
		/// <returns>The <see cref="Task{T}"/></returns>
		Task<T> GetRowAsync(Guid id);
	}
}
