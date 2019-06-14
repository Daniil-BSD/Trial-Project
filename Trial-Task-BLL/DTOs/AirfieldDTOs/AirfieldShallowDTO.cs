using System;

namespace Trial_Task_BLL.DTOs
{
	/*
		Contains all the data from the reequirements + ID; nothing else 
	*/
	public class AirfieldShallowDTO
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
