﻿using System;

namespace Trial_Task.DTOs
{
	public class GPSLogEntryDetailedDTO
	{
		public GPSLogDTO Log { get; set; }
		public DateTime Time { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
