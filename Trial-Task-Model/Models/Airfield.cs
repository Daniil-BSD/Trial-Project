using System;
using System.Collections.Generic;
using Trial_Task_Model.Interfaces;

namespace Trial_Task_Model.Models
{
	/// <summary>
	/// Defines the <see cref="Airfield" /> data structure.
	/// </summary>
	public class Airfield : IGlobalPoint, IGuidIdentifyable
	{
		public ICollection<GPSLog> EndedAt { get; set; }

		public Guid ID { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public string Name { get; set; }

		public ICollection<GPSLog> StartFrom { get; set; }
	}
}
