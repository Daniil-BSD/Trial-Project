using System;

namespace Trial_Task.Domain.Models
{
	public class GPSLogEntry
	{
		public Guid LogID { get; set; }
		public GPSLog Log { get; set; }
		public DateTime Time { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
