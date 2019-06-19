using System;
using System.Collections.Generic;
using Trial_Task_Model.Interfaces;

namespace Trial_Task_Model.Models
{
	/// <summary>
	/// Defines the <see cref="Airfield" />
	/// </summary>
	public class Airfield : IGlobalPoint
	{
		public ICollection<GPSLog> EndedAt { get; set; }

		//Stored
		public Guid ID { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public string Name { get; set; }

		//Computed
		public ICollection<GPSLog> StartFrom { get; set; }
	}
}
