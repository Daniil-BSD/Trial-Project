using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	public class UserDTO
	{
		public Guid Id { get; set; }
		public ICollection<FlightShallowPilotOriginatedDTO> Flights { get; set; }
	}
}
