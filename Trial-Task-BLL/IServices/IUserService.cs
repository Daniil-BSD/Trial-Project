using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;

namespace Trial_Task_BLL.IServices
{
	/// <summary>
	/// Defines the <see cref="IUserService" />
	/// </summary>
	public interface IUserService
	{
		Task<UserShallowDTO> GetAsync(Guid id);

		Task<UserDTO> GetFullAsync(Guid id);

		Task<IEnumerable<UserShallowDTO>> ListAsync();

		Task<IEnumerable<UserBasicDTO>> ListShallowAsync();
	}
}
