using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.APIInterface;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.RoleManagment;
using Trial_Task_Model.Models;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task_WEB.ControllersAPI
{
	/// <summary>
	/// Defines the <see cref="APIUsersController" />
	/// </summary>
	[Route("/api/[controller]")]
	public class APIUsersController : APIBaseController, IAPIUsersController
	{
		protected readonly SignInManager<User> _signInManager;

		private readonly IUserService _userService;

		public APIUsersController(IUserService userService, SignInManager<User> signInManager) : base()
		{
			_userService = userService;
			_signInManager = signInManager;
		}

		[HttpGet]
		public async Task<SpecificObjectResult<IEnumerable<UserShallowDTO>>> GetAllAsync()
		{
			var users = await _userService.ListAsync();
			return new SpecificObjectResult<IEnumerable<UserShallowDTO>>(users);
		}

		[HttpGet("reduced")]
		public async Task<SpecificObjectResult<IEnumerable<UserBasicDTO>>> GetAllReduucedAsync()
		{
			var users = await _userService.ListShallowAsync();
			return new SpecificObjectResult<IEnumerable<UserBasicDTO>>(users);
		}

		[HttpGet("GS{id}")]
		public async Task<SpecificObjectResult<UserShallowDTO>> GetAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var user = await _userService.GetAsync(guid);
				return new SpecificObjectResult<UserShallowDTO>(user);
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<UserShallowDTO>(BadRequest(INVALID_ID_MESSAGE_STRING));
			}
		}

		[HttpGet("userFull")]
		[Authorize]
		public async Task<SpecificObjectResult<UserDTO>> GetCurrentFullUser()
		{
			var response = await _userService.GetCurrentUserFullAsync();
			if (response.Success)
			{
				return new SpecificObjectResult<UserDTO>(response.Value);
			} else
			{
				return new SpecificObjectResult<UserDTO>(BadRequest(response.Message));
			}
		}

		[HttpGet("user")]
		[Authorize]
		public async Task<SpecificObjectResult<UserShallowDTO>> GetCurrentUser()
		{
			var response = await _userService.GetCurrentUserAsync();
			if (response.Success)
			{
				return new SpecificObjectResult<UserShallowDTO>(response.Value);
			} else
			{
				return new SpecificObjectResult<UserShallowDTO>(response.Message, NoContent());
			}
		}

		[HttpGet("GF{id}")]
		public async Task<SpecificObjectResult<UserDTO>> GetFullAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var user = await _userService.GetFullAsync(guid);
				return new SpecificObjectResult<UserDTO>(user);
			}
			catch (FormatException)
			{
				return new SpecificObjectResult<UserDTO>(BadRequest(INVALID_ID_MESSAGE_STRING));
			}
		}

		[HttpGet("IsSignedIn")]
		public SpecificObjectResult<bool> IsSignedIn()
		{
			return new SpecificObjectResult<bool>(_signInManager.IsSignedIn(User));
		}

		[HttpPost("Register")]
		public async Task<SpecificObjectResult<UserBasicDTO>> Register([FromBody] UserRegistrationDTO userRegistrationDTO)
		{
			if (!ModelState.IsValid)
				return new SpecificObjectResult<UserBasicDTO>(BadRequest(INVALID_MODEL_MESSAGE_STRING));
			SignOut();
			var response = await _userService.RegisterAsync(userRegistrationDTO);
			if (response.Success)
				return new SpecificObjectResult<UserBasicDTO>(response.Value);
			return new SpecificObjectResult<UserBasicDTO>(BadRequest(response.Message));
		}

		[HttpPost("SignIn")]
		public async Task<SpecificObjectResult<UserBasicDTO>> SignIn([FromBody] UserLoginDTO userRegistrationDTO)
		{
			if (!ModelState.IsValid)
				return new SpecificObjectResult<UserBasicDTO>(BadRequest(INVALID_MODEL_MESSAGE_STRING));
			SignOut();
			var response = await _userService.SignInAsync(userRegistrationDTO);
			if (response.Success)
				return new SpecificObjectResult<UserBasicDTO>(response.Value);
			return new SpecificObjectResult<UserBasicDTO>(BadRequest(response.Message));
		}

		[HttpPost("SignOut")]
		[Authorize]
		public async void SignOut()
		{
			await _signInManager.SignOutAsync();
		}

		[HttpPost("GrantAdminStatus/{userName}")]
		//[Authorize(Policy = Policies.RESTRICTED)]
		public async void GrantAdminStatusAsync(string userName)
		{
			try
			{
				await _userService.GrantAdminStatusAsync(userName);
			}
			catch (FormatException)
			{
			}
		}
	}
}
