using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Services;
using Trial_Task.DTOs;

namespace Trial_Task.Controllers
{
	[Route("/api/[controller]")]
	public class UsersController : BaseController
	{

		private readonly IUserService _userService;

		public UsersController(IUserService userService, IMapper mapper) : base(mapper)
		{
			_userService = userService;
		}

		[HttpGet]
		public async Task<IEnumerable<UserShallowDTO>> GetAllAsync()
		{
			var users = await _userService.ListAsync();
			var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserShallowDTO>>(users);
			return resources;
		}

		[HttpGet("reduced")]
		public async Task<IEnumerable<UserBasicDTO>> GetAllReduucedAsync()
		{
			var users = await _userService.ListShallowAsync();
			var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserBasicDTO>>(users);
			return resources;
		}

		[HttpGet("GF{id}")]
		public async Task<UserDTO> GetFullAsync(string id)
		{
			try
			{
				var guid = new Guid(id);
				var user = await _userService.GetFullAsync(guid);
				var resource = _mapper.Map<User, UserDTO>(user);
				return resource;
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
				var resource = _mapper.Map<User, UserShallowDTO>(user);
				return resource;
			}
			catch (FormatException)
			{
				return null;
			}
		}
	}
}
