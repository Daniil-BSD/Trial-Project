using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Resoursces
{
	public class GPSLogEntryResoursces
	{
		public Guid LogID { get; set; }
		public GPSLog Log { get; set; }
		public DateTime Time { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
