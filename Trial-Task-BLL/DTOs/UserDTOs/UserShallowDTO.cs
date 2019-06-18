using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	public class UserShallowDTO
	{
		public Guid Id { get; set; }
		public ICollection<FlightBasicPilotOriginatedDTO> Flights { get; set; }
	}
}
