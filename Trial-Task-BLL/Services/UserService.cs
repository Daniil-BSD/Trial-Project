using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Services
{
	/// <summary>
	/// Defines the <see cref="UserService" />
	/// </summary>
	public class UserService : BaseService, IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository, IMapper mapper) : base(mapper)
		{
			_userRepository = userRepository;
		}

		public async Task<UserShallowDTO> GetAsync(Guid id)
		{
			var user = await _userRepository.GetAsync(id);
			return _mapper.Map<User, UserShallowDTO>(user);
		}

		public async Task<UserDTO> GetFullAsync(Guid id)
		{
			var user = await _userRepository.GetFullAsync(id);
			return _mapper.Map<User, UserDTO>(user);
		}

		public async Task<IEnumerable<UserShallowDTO>> ListAsync()
		{
			var users = await _userRepository.ListAsync();
			return _mapper.Map<IEnumerable<User>, IEnumerable<UserShallowDTO>>(users);
		}

		public async Task<IEnumerable<UserBasicDTO>> ListShallowAsync()
		{
			var users = await _userRepository.ListShallowAsync();
			return _mapper.Map<IEnumerable<User>, IEnumerable<UserBasicDTO>>(users);
		}
	}
}
