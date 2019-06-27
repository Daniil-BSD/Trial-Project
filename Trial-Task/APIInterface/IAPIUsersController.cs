using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task.APIInterface
{
	public interface IAPIUsersController
	{

		Task<SpecificObjectResult<IEnumerable<UserShallowDTO>>> GetAllAsync();

		Task<SpecificObjectResult<IEnumerable<UserBasicDTO>>> GetAllReduucedAsync();
		Task<SpecificObjectResult<UserShallowDTO>> GetAsync(string id);
		Task<SpecificObjectResult<UserDTO>> GetCurrentFullUser();
		Task<SpecificObjectResult<UserShallowDTO>> GetCurrentUser();
		Task<SpecificObjectResult<UserDTO>> GetFullAsync(string id);
		SpecificObjectResult<bool> IsSignedIn();
		Task<SpecificObjectResult<UserBasicDTO>> Register(UserRegistrationDTO userRegistrationDTO);
		Task<SpecificObjectResult<UserBasicDTO>> SignIn(UserLoginDTO userRegistrationDTO);
		void SignOut();
	}
}
