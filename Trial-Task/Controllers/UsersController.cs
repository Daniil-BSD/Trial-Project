using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_Model.Models;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task_WEB.Controllers
{
	/// <summary>
	/// Defines the <see cref="UsersController" />
	/// </summary>
	[Route("/api/[controller]")]
	public class UsersController : BaseController
	{
		protected readonly SignInManager<User> _signInManager;

		private readonly IUserService _userService;

		public UsersController(IUserService userService, SignInManager<User> signInManager) : base()
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
			var response = await _userService.SignInAsync(userRegistrationDTO);
			if (response.Success)
				return new SpecificObjectResult<UserBasicDTO>(response.Value);
			return new SpecificObjectResult<UserBasicDTO>(BadRequest(response.Message));
		}

		[HttpPost("SignOut")]
		public async void SignOut()
		{
			await _signInManager.SignOutAsync();
		}
	}
}
