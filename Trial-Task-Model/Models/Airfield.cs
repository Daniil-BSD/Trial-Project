using System;
using System.Collections.Generic;

namespace Trial_Task_Model.Models
{
	public class Airfield
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public ICollection<GPSLog> StartFrom { get; set; }
		public ICollection<GPSLog> EndedAt { get; set; }
	}
}
