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
		private readonly IUserService _userService;
		protected readonly SignInManager<User> _signInManager;

		public UsersController(IUserService userService, SignInManager<User> signInManager) : base()
		{
			_userService = userService;
			_signInManager = signInManager;
		}

		[HttpGet]
		public async Task<SpecificObjectResult< IEnumerable<UserShallowDTO>>> GetAllAsync()
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

		[HttpPost("register")]
		public async Task<SpecificObjectResult<UserBasicDTO>> Register([FromBody] UserRegistrationDTO userRegistrationDTO)
		{
			if (!ModelState.IsValid)
				return new SpecificObjectResult<UserBasicDTO>(BadRequest(INVALID_MODEL_MESSAGE_STRING));
			var response = await _userService.RegisterAsync(userRegistrationDTO);
			if (response.Success)
				return new SpecificObjectResult<UserBasicDTO>(response.Value);
			return new SpecificObjectResult<UserBasicDTO>(BadRequest(response.Message));
		}

		[HttpGet("user")]
		public async Task<SpecificObjectResult<UserBasicDTO>> GetCurrentUser()
		{
			var response = await _userService.GetCurrentUser();
			if (response.Success)
			{
				return new SpecificObjectResult<UserBasicDTO>(response.Value);
			} else { 
				return new SpecificObjectResult<UserBasicDTO>(response.Message, NoContent());
			}
		}
		[HttpGet("ISuser")]
		public SpecificObjectResult<string> IsSignedInn()
		{
			return new SpecificObjectResult<string>(_signInManager.IsSignedIn(User).ToString());
		}
	}
}
