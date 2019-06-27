using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.Responses;
using Trial_Task_BLL.RoleManagment;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;
using static Trial_Task_BLL.RoleManagment.Role;

namespace Trial_Task_BLL.Services
{
	/// <summary>
	/// Defines the <see cref="UserService" />
	/// </summary>
	public class UserService : BaseService, IUserService
	{
		protected readonly UserManager<User> _userManager;

		private readonly IUserRepository _userRepository;

		public UserService(
			IUserRepository userRepository,
			UserManager<User> userManager,
			IMapper mapper,
			SignInManager<User> signInManager
			) : base(mapper, signInManager)
		{
			_userRepository = userRepository;
			_userManager = userManager;
		}

		public async Task<Response<UserShallowDTO>> GetAsync(Guid id)
		{
			var task = _userRepository.GetAsync(id);
			return await Response<UserShallowDTO>.CatchInvalidOperationExceptionAndMap(task, _mapper);
		}

		[Authorize]
		public async Task<Response<UserShallowDTO>> GetCurrentUserAsync()
		{
			var response = GetCurrentUserID();
			if (response.Success)
			{
				User user = await _userRepository.GetAsync(response.Value);
				return new Response<UserShallowDTO>(_mapper.Map<User, UserShallowDTO>(user));
			} else
			{
				return new Response<UserShallowDTO>(response.Message);
			}
		}

		[Authorize]
		public async Task<Response<UserDTO>> GetCurrentUserFullAsync()
		{
			var response = GetCurrentUserID();
			if (response.Success)
			{
				User user = await _userRepository.GetFullAsync(response.Value);
				return new Response<UserDTO>(_mapper.Map<User, UserDTO>(user));
			} else
			{
				return new Response<UserDTO>(response.Message);
			}
		}

		public Response<Guid> GetCurrentUserID()
		{
			bool signedIn = _signInManager.IsSignedIn(_signInManager.Context.User);
			if (signedIn)
			{
				try
				{
					return new Response<Guid>(new Guid(_userManager.GetUserId(_signInManager.Context.User)));
				}
				catch (FormatException)
				{
					return new Response<Guid>("Unable to convert string to Guid");
				}
			} else
			{
			}
			return new Response<Guid>("User is not signed in.");
		}

		public async Task<Response<UserDTO>> GetFullAsync(Guid id)
		{
			var task = _userRepository.GetFullAsync(id);
			return await Response<UserDTO>.CatchInvalidOperationExceptionAndMap(task, _mapper);
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

		public async Task<Response<UserBasicDTO>> RegisterAsync(UserRegistrationDTO userRegistrationDTO)
		{
			try
			{
				User user = _mapper.Map<UserRegistrationDTO, User>(userRegistrationDTO);
				IdentityResult result = await _userManager.CreateAsync(user, userRegistrationDTO.Password);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, true, "Registration");
					await _userManager.AddToRoleAsync(user, RoleEnum.Member.GetName());
					return new Response<UserBasicDTO>(_mapper.Map<User, UserBasicDTO>(user));
				} else
				{
					string message = "";
					foreach (var error in result.Errors)
					{
						message += error.Description + " ";
					}
					return new Response<UserBasicDTO>(message);
				}
			}
			catch (Exception e)
			{
				return new Response<UserBasicDTO>(e.Message);
			}
		}

		public async Task<Response<UserBasicDTO>> SignInAsync(UserLoginDTO userLoginDTO)
		{
			SignInResult result = await _signInManager.PasswordSignInAsync(userLoginDTO.UserName, userLoginDTO.Password, true, false);
			if (result.Succeeded)
			{
				var user = await _userManager.FindByNameAsync(userLoginDTO.UserName);
				//Not catching: "User not logged in", "No such user", "string => Guid conversion"; because Sign in was sucessful
				return new Response<UserBasicDTO>(_mapper.Map<User, UserBasicDTO>(user));
			} else
			{
				if (result.IsLockedOut)
					return new Response<UserBasicDTO>("User is locked out.");
				if (result.IsNotAllowed)
					return new Response<UserBasicDTO>("Not Allowed to log in.");
				return new Response<UserBasicDTO>("Specified user does not exsist, or forbidden from logging in.");
			}
		}
	}
}
