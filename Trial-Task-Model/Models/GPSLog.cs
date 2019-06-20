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

		public List<GPSLogEntry> Entries { get; set; }

		public Flight Flight { get; set; }

		public Guid ID { get; set; }

		public Guid? LandingID { get; set; }

		public Airfield PlaceOfLanding { get; set; }

		public Airfield PlaceOfTakeoff { get; set; }

		public Guid? TakeoffID { get; set; }
	}
}
