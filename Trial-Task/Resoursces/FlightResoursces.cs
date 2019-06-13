using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Resoursces
{
	public class FlightResoursce
	{
		public Guid ID { get; set; }

		public DateTime Date { get; set; }
		public EFlightStatus Status { get; set; }

		public Guid LogID { get; set; }
		public GPSLog Log { get; set; }

		public Guid UserID { get; set; }
		public User Pilot { get; set; }
	}
}
