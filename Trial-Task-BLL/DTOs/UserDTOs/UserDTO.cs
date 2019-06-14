using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	public class UserDTO
	{
		public Guid Guid_ID { get; set; }
		public ICollection<FlightShallowPilotOriginatedDTO> Flights { get; set; }
	}
}
