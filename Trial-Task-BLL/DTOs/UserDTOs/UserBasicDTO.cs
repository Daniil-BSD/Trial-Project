using System;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="UserBasicDTO" />
	/// </summary>
	public class UserBasicDTO
	{
		public Guid Id { get; set; }

		public string UserName { get; set; }



		public static implicit operator UserBasicDTO(UserShallowDTO shallowDTO)
		{
			return new UserBasicDTO { Id = shallowDTO.Id, UserName = shallowDTO.UserName };
		}
	}
}
