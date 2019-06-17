using System;
using System.Collections.Generic;
using Trial_Task_Model.Interfaces;

namespace Trial_Task_Model.Models
{
	public class Airfield: IGlobalPoint
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public ICollection<GPSLog> StartFrom { get; set; }
		public ICollection<GPSLog> EndedAt { get; set; }
	}
}
