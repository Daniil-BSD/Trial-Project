using System;
using System.Collections.Generic;

namespace Trial_Task.DTOs
{
	public class UserShallowDTO
	{
		public Guid Guid_ID { get; set; }
		public ICollection<FlightBasicPilotOriginatedDTO> Flights { get; set; }
	}
}
