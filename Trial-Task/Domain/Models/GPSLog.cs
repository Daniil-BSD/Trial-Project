using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trial_Task.Domain.Models
{
    public class GPSLog
    {
		public Guid ID { get; set; }
		public Flight Flight { get; set; }

		public LinkedList<GPSLogEntry> Entries { get; set; }
		public TimeSpan Duration { get; set; }
		public Guid TakeoffID { get; set; }
		public Airfield PlaceOfTakeoff { get; set; }
		public Guid LandingID { get; set; }
		public Airfield PlaceOfLanding { get; set; }
	}
}
