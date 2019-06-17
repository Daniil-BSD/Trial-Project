using System;
using Trial_Task_Model.Interfaces;

namespace Trial_Task_Model.Models
{
	public class GPSLogEntry : IGlobalPoint
	{
		public Guid LogID { get; set; }
		public GPSLog Log { get; set; }
		public DateTime Time { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
