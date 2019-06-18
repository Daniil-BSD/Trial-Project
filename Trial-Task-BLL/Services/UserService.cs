using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.Responses;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http;

namespace Trial_Task_BLL.Services
{
	/// <summary>
	/// Defines the <see cref="UserService" />
	/// </summary>
	public class UserService : BaseService, IUserService
	{

		protected readonly UserManager<User> _userManager;
		private readonly IUserRepository _userRepository;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserService(
			IUserRepository userRepository,
			UserManager<User> userManager,
			IHttpContextAccessor httpContextAccessor,
			IMapper mapper,
			SignInManager<User> signInManager
			) : base(mapper, signInManager)
		{
			_userRepository = userRepository;
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
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

		public async Task<Response<UserBasicDTO>> RegisterAsync(UserRegistrationDTO userRegistrationDTO)
		{
			try
			{
				User user = _mapper.Map<UserRegistrationDTO, User>(userRegistrationDTO);
				IdentityResult result = await _userManager.CreateAsync(user, userRegistrationDTO.Password);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, true);
					return new Response<UserBasicDTO>(_mapper.Map<User, UserBasicDTO>(user));
				} else {
					string message = "";
					foreach (var error in result.Errors) {
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

		public async Task<Response<UserBasicDTO>> GetCurrentUser() {
			bool signedIn = _signInManager.IsSignedIn(_httpContextAccessor.HttpContext.User);
			if (signedIn)
			{
				User user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
				return new Response<UserBasicDTO>(_mapper.Map<User, UserBasicDTO>(user));
			} else {

				return new Response<UserBasicDTO>("Not signed in");
			}
		}
	}
}
