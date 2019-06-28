using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.Responses;

namespace Trial_Task_BLL.IServices
{
	/// <summary>
	/// Defines the <see cref="IUserService" />
	/// </summary>
	public interface IUserService
	{
		Task<Response<UserShallowDTO>> GetAsync(Guid id);

		Task<Response<UserShallowDTO>> GetCurrentUserAsync();

		Task<Response<UserDTO>> GetCurrentUserFullAsync();

		Response<Guid> GetCurrentUserID();

		Task<Response<UserDTO>> GetFullAsync(Guid id);

		Task<Response<bool>> GrantAdminStatusAsync(string login);

		Task<IEnumerable<UserShallowDTO>> ListAsync();

		Task<IEnumerable<UserBasicDTO>> ListShallowAsync();

		Task<Response<UserBasicDTO>> RegisterAsync(UserRegistrationDTO userRegistrationDTO);

		Task<Response<UserBasicDTO>> SignInAsync(UserLoginDTO userRegistrationDTO);
	}
}
