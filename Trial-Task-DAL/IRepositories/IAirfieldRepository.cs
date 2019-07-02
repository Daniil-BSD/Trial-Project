using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Trial_Task_Model.Interfaces;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	/// <summary>
	/// Defines the <see cref="IAirfieldRepository" />
	/// </summary>
	public interface IAirfieldRepository : IRepositoryForGuiDIdentifyables<Airfield>
	{
		/// <summary>
		/// The <see cref="ListAsync()"/> equivalent with an ability to provide a filtering function.
		/// </summary>
		/// <param name="func">The filtering function<see cref="Func{Airfield, bool}"/></param>
		/// <returns>The <see cref="Task{List{Airfield}}"/> of elements that that satified the function.</returns>
		Task<List<Airfield>> FilterListAsync(Expression<Func<Airfield, bool>> func);

		/// <summary>
		/// The <see cref="ListShallowAsync()"/> equivalent with an ability to provide a filtering function.
		/// </summary>
		/// <param name="func">The filtering function<see cref="Func{Airfield, bool}"/></param>
		/// <returns>The <see cref="Task{List{Airfield}}"/> of elements that that satified the function.</returns>
		Task<List<Airfield>> FilterListShallowAsync(Expression<Func<Airfield, bool>> func);

		/// <summary>
		/// The method for finding the Airfield near (defined by <see cref="AIRFIELD_DESIGNATED_AREA_RADIUS"/>) the specified point.
		/// This method is NOT searching for the closest Airfield.
		/// </summary>
		/// <param name="globalPoint">The <see cref="IGlobalPoint"/> around which the search is performed</param>
		/// <returns>The <see cref="Task{Airfield}"/></returns>
		Task<Airfield> FindAround(IGlobalPoint globalPoint);

		/// <summary>
		/// Standart Get method for a single <see cref="Airfield"/>
		/// </summary>
		/// <param name="id">The <see cref="Guid"/> id.</param>
		/// <returns>The <see cref="Task{Airfield}"/></returns>
		Task<Airfield> GetAsync(Guid id);

		/// <summary>
		/// Get method for a single <see cref="Airfield"/> with minimal includes.
		/// </summary>
		/// <param name="id">The <see cref="Guid"/> id.</param>
		/// <returns>The <see cref="Task{Airfield}"/></returns>
		Task<Airfield> GetShallowAsync(Guid id);

		/// <summary>
		/// List all the Airfields in the database fully.
		/// (<see cref="GetAsync(Guid)"/> for each guid and optimised)
		/// </summary>
		/// <returns>The <see cref="Task{Airfield}"/></returns>
		Task<List<Airfield>> ListAsync();

		/// <summary>
		/// List basic information of all the Airfields in the database.
		/// (<see cref="GetShallowAsync(Guid)"/> for each guid and optimised)
		/// </summary>
		/// <returns>The <see cref="Task{Airfield}"/></returns>
		Task<List<Airfield>> ListShallowAsync();

		/// <summary>
		/// Inserts a new Airfield in a Database ( and asigning it an ID) without validation.
		/// </summary>
		/// <param name="airfield">The <see cref="Airfield"> to be added.</param>
		/// <returns>The <see cref="Task{Airfield}"/> that was just added(contains a populated ID field)</returns>
		Task<Airfield> UnvalidatedInsertAsync(Airfield airfield);
	}
}
