﻿using System.ComponentModel.DataAnnotations;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="UserRegistrationDTO" />
	/// </summary>
	public class UserRegistrationDTO
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		public string UserName { get; set; }
	}
}
