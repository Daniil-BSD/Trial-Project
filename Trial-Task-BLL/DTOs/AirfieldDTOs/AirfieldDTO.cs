﻿using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	/*
	*	A complete replica of the Airfield class, created to pivide a modification point and because there is no protected information in it
	*/
	/// <summary>
	/// Defines the <see cref="AirfieldDTO" />
	/// </summary>
	public class AirfieldDTO
	{
		public ICollection<GPSLogBasicDTO> EndedAt { get; set; }

		public Guid ID { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public string Name { get; set; }

		public ICollection<GPSLogBasicDTO> StartFrom { get; set; }
	}
}
