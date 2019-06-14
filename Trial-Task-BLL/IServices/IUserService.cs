using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;

namespace Trial_Task_BLL.IServices
{
	public interface IUserService
	{
		Task<IEnumerable<UserShallowDTO>> ListAsync();
		Task<IEnumerable<UserBasicDTO>> ListShallowAsync();
		Task<UserDTO> GetFullAsync(Guid id);
		Task<UserShallowDTO> GetAsync(Guid id);
	}
}
