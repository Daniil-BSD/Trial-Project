using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Resoursces
{
	public class UserResoursces
	{
		public Guid Guid_ID { get; set; }
		public ICollection<Flight> Flights { get; set; }
	}
}
