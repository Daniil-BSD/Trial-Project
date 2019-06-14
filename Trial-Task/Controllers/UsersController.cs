using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;

namespace Trial_Task_WEB.Controllers
{
	[Route("/api/[controller]")]
	public class UsersController : BaseController
	{

		private readonly IUserService _userService;

		public UsersController(IUserService userService) : base()
		{
			_userService = userService;
		}

		[HttpGet]
		public async Task<IEnumerable<UserShallowDTO>> GetAllAsync()
		{
			var users = await _userService.ListAsync();
			return users;
		}

		[HttpGet("reduced")]
		public async Task<IEnumerable<UserBasicDTO>> GetAllReduucedAsync()
		{
			var users = await _userService.ListShallowAsync();
			return users;
		}

		[HttpGet("GF{id}")]
		public async Task<UserDTO> GetFullAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var user = await _userService.GetFullAsync(guid);
				return user;
			}
			catch (FormatException)
			{
				return null;
			}
		}

		[HttpGet("GS{id}")]
		public async Task<UserShallowDTO> GetAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var user = await _userService.GetAsync(guid);
				return user;
			}
			catch (FormatException)
			{
				return null;
			}
		}
	}
}
