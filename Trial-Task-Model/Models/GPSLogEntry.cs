using System;
using Trial_Task_Model.Interfaces;

namespace Trial_Task_Model.Models
{
	/// <summary>
	/// Defines the <see cref="GPSLogEntry" />
	/// </summary>
	public class GPSLogEntry : IGlobalPoint
	{
		public double Latitude { get; set; }

		//Computed
		public GPSLog Log { get; set; }

		//Stored
		public Guid LogID { get; set; }

		public double Longitude { get; set; }

		public DateTime Time { get; set; }
	}
}
