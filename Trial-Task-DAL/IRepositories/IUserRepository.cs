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
		Task<User> GetAsync(Guid id);

		Task<User> GetFullAsync(Guid id);

		Task<IEnumerable<User>> ListAsync();

		Task<IEnumerable<User>> ListShallowAsync();
	}
}
