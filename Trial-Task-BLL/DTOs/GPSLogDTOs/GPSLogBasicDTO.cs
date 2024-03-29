﻿using System;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="GPSLogBasicDTO" />
	/// </summary>
	public class GPSLogBasicDTO
	{
		public double ApproxLength { get; set; }

		public TimeSpan Duration { get; set; }

		public Guid ID { get; set; }

		public AirfieldBasicDTO PlaceOfLanding { get; set; }

		public AirfieldBasicDTO PlaceOfTakeoff { get; set; }

		public double RegisteredLength { get; set; }
	}
}
