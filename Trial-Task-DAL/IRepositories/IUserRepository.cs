using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	/// <summary>
	/// Defines the <see cref="IUserRepository" />
	/// </summary>
	public interface IUserRepository
	{
		/// <summary>
		/// Standart Get method for a single <see cref="User"/>
		/// (Does not include <see cref="GPSLogEntry"/> log information)
		/// </summary>
		/// <param name="id">The <see cref="Guid"/> id.</param>
		/// <returns>The <see cref="Task{User}"/></returns>
		Task<User> GetAsync(Guid id);

		/// <summary>
		/// Extensive Get method for a single <see cref="User"/>
		/// (Does include <see cref="GPSLogEntry"/> log information)
		/// </summary>
		/// <param name="id">The <see cref="Guid"/> id.</param>
		/// <returns>The <see cref="Task{User}"/></returns>
		Task<User> GetFullAsync(Guid id);

		/// <summary>
		/// Lists all Users in the Database (<see cref="GetAsync(Guid)"/>)
		/// </summary>
		/// <returns>The <see cref="Task{List{User}}"/></returns>
		Task<List<User>> ListAsync();

		/// <summary>
		/// Lists all the users without listing their flights
		/// </summary>
		/// <returns>The <see cref="Task{List{User}}"/></returns>
		Task<List<User>> ListShallowAsync();
	}
}
