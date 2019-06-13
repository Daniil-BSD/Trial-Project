using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Resoursces
{
	/*
		A complete replica of the Airfield class, created to pivide a modification point and because there is no protected information in it
	*/
	public class AirfieldResource
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public ICollection<GPSLog> StartFrom { get; set; }
		public ICollection<GPSLog> EndedAt { get; set; }
	}

	/*
		Contains all the data from the reequirements + ID; nothing else 
	*/
	public class AirfieldShallowResource
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}

	/*
		Contains only Name and ID, could be used for the reduction of traffic, for cases when name would be enough.
	*/
	public class AirfieldBaisicResource
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
	}
}
