using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Repositories;
using Trial_Task.Domain.Services;

namespace Trial_Task.Services
{
	public class UserService : IUserService
	{

		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<User> GetAsync(Guid id)
		{
			return await _userRepository.GetAsync(id);
		}

		public async Task<User> GetFullAsync(Guid id)
		{
			return await _userRepository.GetFullAsync(id);
		}

		public async Task<IEnumerable<User>> ListAsync()
		{
			return await _userRepository.ListAsync();
		}

		public async Task<IEnumerable<User>> ListShallowAsync()
		{
			return await _userRepository.ListShallowAsync();
		}
	}
}
