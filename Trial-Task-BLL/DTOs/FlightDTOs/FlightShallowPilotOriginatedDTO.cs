﻿using System;
using Trial_Task_Model.Enumerations;

namespace Trial_Task_BLL.DTOs
{
	public class FlightShallowPilotOriginatedDTO
	{
		public Guid ID { get; set; }
		public DateTime Date { get; set; }
		public EFlightStatus Status { get; set; }
		public GPSLogShallowDTO Log { get; set; }
	}
}