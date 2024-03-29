﻿using System.ComponentModel.DataAnnotations;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="AirfieldSaveDTO" />
	/// </summary>
	public class AirfieldSaveDTO
	{
		[Required]
		public double Latitude { get; set; }

		[Required]
		public double Longitude { get; set; }

		[Required]
		public string Name { get; set; }
	}
}
