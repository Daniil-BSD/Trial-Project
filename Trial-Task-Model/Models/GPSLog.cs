using System;
using System.Collections.Generic;

namespace Trial_Task_Model.Models
{
	public class GPSLog
	{
		//Stored
		public Guid ID { get; set; }
		public LinkedList<GPSLogEntry> Entries { get; set; }
		//Computed on creation
		public TimeSpan Duration { get; set; }
		public Guid TakeoffID { get; set; }
		public Guid LandingID { get; set; }
		//Computed
		public Flight Flight { get; set; }
		public Airfield PlaceOfTakeoff { get; set; }
		public Airfield PlaceOfLanding { get; set; }
	}
}
