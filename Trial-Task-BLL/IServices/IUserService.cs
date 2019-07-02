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
		/// <summary>
		/// The GetAsync
		/// </summary>
		/// <param name="id">The id<see cref="Guid"/></param>
		/// <returns>The <see cref="Task{Response{UserShallowDTO}}"/></returns>
		Task<Response<UserShallowDTO>> GetAsync(Guid id);

		/// <summary>
		/// The GetCurrentUserAsync
		/// </summary>
		/// <returns>The <see cref="Task{Response{UserShallowDTO}}"/></returns>
		Task<Response<UserShallowDTO>> GetCurrentUserAsync();

		/// <summary>
		/// The GetCurrentUserFullAsync
		/// </summary>
		/// <returns>The <see cref="Task{Response{UserDTO}}"/></returns>
		Task<Response<UserDTO>> GetCurrentUserFullAsync();

		/// <summary>
		/// The GetCurrentUserID
		/// </summary>
		/// <returns>The <see cref="Response{Guid}"/></returns>
		Response<Guid> GetCurrentUserID();

		/// <summary>
		/// The GetFullAsync
		/// </summary>
		/// <param name="id">The id<see cref="Guid"/></param>
		/// <returns>The <see cref="Task{Response{UserDTO}}"/></returns>
		Task<Response<UserDTO>> GetFullAsync(Guid id);

		/// <summary>
		/// The GrantAdminStatusAsync
		/// </summary>
		/// <param name="login">The login<see cref="string"/></param>
		/// <returns>The <see cref="Task{Response{bool}}"/></returns>
		Task<Response<bool>> GrantAdminStatusAsync(string login);

		/// <summary>
		/// The ListAsync
		/// </summary>
		/// <returns>The <see cref="Task{IEnumerable{UserShallowDTO}}"/></returns>
		Task<IEnumerable<UserShallowDTO>> ListAsync();

		/// <summary>
		/// The ListShallowAsync
		/// </summary>
		/// <returns>The <see cref="Task{IEnumerable{UserBasicDTO}}"/></returns>
		Task<IEnumerable<UserBasicDTO>> ListShallowAsync();

		/// <summary>
		/// The RegisterAsync
		/// </summary>
		/// <param name="userRegistrationDTO">The userRegistrationDTO<see cref="UserRegistrationDTO"/></param>
		/// <returns>The <see cref="Task{Response{UserBasicDTO}}"/></returns>
		Task<Response<UserBasicDTO>> RegisterAsync(UserRegistrationDTO userRegistrationDTO);

		/// <summary>
		/// The SignInAsync
		/// </summary>
		/// <param name="userRegistrationDTO">The userRegistrationDTO<see cref="UserLoginDTO"/></param>
		/// <returns>The <see cref="Task{Response{UserBasicDTO}}"/></returns>
		Task<Response<UserBasicDTO>> SignInAsync(UserLoginDTO userRegistrationDTO);
	}
}
