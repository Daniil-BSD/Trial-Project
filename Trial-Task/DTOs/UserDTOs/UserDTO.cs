using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trial_Task.DTOs
{
	public class UserDTO
	{
		public Guid Guid_ID { get; set; }
		public ICollection<FlightBasicDTO> Flights { get; set; }
	}
}
