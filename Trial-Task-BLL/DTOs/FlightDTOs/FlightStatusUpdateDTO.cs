using System;
using System.ComponentModel.DataAnnotations;
using Trial_Task_Model.Enumerations;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="FlightStatusUpdateDTO" />
	/// </summary>
	public class FlightStatusUpdateDTO
	{
		[Required]
		public EFlightStatus Status { get; set; }

		[Required]
		public Guid Target { get; set; }
	}
}
