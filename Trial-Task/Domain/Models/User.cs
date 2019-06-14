using System;
using System.Collections.Generic;

namespace Trial_Task.Domain.Models
{
	public class User //: IdentityUser
	{
		public Guid Guid_ID { get; set; }
		public ICollection<Flight> Flights { get; set; }
	}
}
