using System;
using System.Collections.Generic;

namespace Trial_Task_Model.Models
{
	public class User //: IdentityUser
	{
		public Guid Guid_ID { get; set; }
		public ICollection<Flight> Flights { get; set; }
	}
}
