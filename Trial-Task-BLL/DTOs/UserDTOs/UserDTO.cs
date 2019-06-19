using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="UserDTO" />
	/// </summary>
	public class UserDTO
	{
		public ICollection<FlightShallowPilotOriginatedDTO> Flights { get; set; }

		public Guid Id { get; set; }
	}
}
