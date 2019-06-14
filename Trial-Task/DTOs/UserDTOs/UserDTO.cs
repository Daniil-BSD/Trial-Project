using System;
using System.Collections.Generic;

namespace Trial_Task.DTOs
{
	public class UserDTO
	{
		public Guid Guid_ID { get; set; }
		public ICollection<FlightShallowPilotOriginatedDTO> Flights { get; set; }
	}
}
