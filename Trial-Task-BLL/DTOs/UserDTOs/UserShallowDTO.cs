using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="UserShallowDTO" />
	/// </summary>
	public class UserShallowDTO
	{
		public ICollection<FlightBasicPilotOriginatedDTO> Flights { get; set; }

		public string UserName { get; set; }

		public Guid Id { get; set; }
	}
}
