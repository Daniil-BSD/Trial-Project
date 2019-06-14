﻿using System;
using Trial_Task_Model.Enumerations;

namespace Trial_Task_BLL.DTOs
{
	public class FlightShallowDTO
	{
		public Guid ID { get; set; }
		public DateTime Date { get; set; }
		public EFlightStatus Status { get; set; }
		public GPSLogShallowDTO Log { get; set; }
		public UserShallowDTO Pilot { get; set; }
	}
}