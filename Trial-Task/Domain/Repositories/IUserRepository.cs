using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Domain.Repositories
{
	public interface IUserRepository
	{
		Task<User> GetAsync(Guid id);
		Task<User> GetFullAsync(Guid id);
		Task<IEnumerable<User>> ListShallowAsync();
		Task<IEnumerable<User>> ListAsync();
	}
}
