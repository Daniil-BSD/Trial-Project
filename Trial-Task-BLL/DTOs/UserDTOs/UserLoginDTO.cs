using System.ComponentModel.DataAnnotations;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="UserLoginDTO" />
	/// </summary>
	public class UserLoginDTO
	{
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		public string UserName { get; set; }
	}
}
