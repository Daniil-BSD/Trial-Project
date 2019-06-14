using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Domain.Services
{
	public interface IUserService
	{
		Task<IEnumerable<User>> ListAsync();
		Task<IEnumerable<User>> ListShallowAsync();
		Task<User> GetFullAsync(Guid id);
		Task<User> GetAsync(Guid id);
	}
}
