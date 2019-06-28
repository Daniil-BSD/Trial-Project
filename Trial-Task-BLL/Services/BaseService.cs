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

		public BaseService(IMapper mapper)
		{
			_mapper = mapper;
		}
	}
}
