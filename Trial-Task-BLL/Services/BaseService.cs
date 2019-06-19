using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Services
{
	/// <summary>
	/// Defines the <see cref="BaseService" />
	/// </summary>
	public class BaseService
	{
		protected readonly IMapper _mapper;

		protected readonly SignInManager<User> _signInManager;

		public BaseService(IMapper mapper, SignInManager<User> signInManager)
		{
			_mapper = mapper;
			_signInManager = signInManager;
		}
	}
}
