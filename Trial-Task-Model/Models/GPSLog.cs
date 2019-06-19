using System;
using System.Collections.Generic;

namespace Trial_Task_Model.Models
{
	/// <summary>
	/// Defines the <see cref="GPSLog" />
	/// </summary>
	public class GPSLog
	{
		//Computed on creation
		public TimeSpan Duration { get; set; }

		public LinkedList<GPSLogEntry> Entries { get; set; }

		//Computed
		public Flight Flight { get; set; }

		//Stored
		public Guid ID { get; set; }

		public Guid LandingID { get; set; }

		public Airfield PlaceOfLanding { get; set; }

		public Airfield PlaceOfTakeoff { get; set; }

		public Guid TakeoffID { get; set; }
	}
}
