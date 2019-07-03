using System;
using System.Collections.Generic;
using Trial_Task_Model.Interfaces;

namespace Trial_Task_Model.Models
{
	/// <summary>
	/// Defines the <see cref="GPSLog" /> data structure.
	/// </summary>
	public class GPSLog : IGuidIdentifyable
	{
		public double ApproxLength { get; set; }

		public TimeSpan Duration { get; set; }

		public List<GPSLogEntry> Entries { get; set; }

		public Flight Flight { get; set; }

		public Guid ID { get; set; }

		public Guid? LandingID { get; set; }

		public Airfield PlaceOfLanding { get; set; }

		public Airfield PlaceOfTakeoff { get; set; }

		public double RegisteredLength { get; set; }

		public Guid? TakeoffID { get; set; }
	}
}
