﻿using System;
using Trial_Task_Model.Enumerations;

namespace Trial_Task_Model.Models
{
	/// <summary>
	/// Defines the <see cref="Flight" />
	/// </summary>
	public class Flight
	{
		public DateTime Date { get; set; }

		//Stored
		public Guid ID { get; set; }

		//Computed
		public GPSLog Log { get; set; }

		public Guid LogID { get; set; }

		public User Pilot { get; set; }

		public EFlightStatus Status { get; set; }

		public Guid UserID { get; set; }
	}
}
