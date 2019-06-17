using System;

namespace Trial_Task_BLL.DTOs
{
	/*
		Contains all the data from the reequirements + ID; nothing else 
		Also could be treated as an equvivalent of a Database row in an Airfields table. (no computed fields)
	*/
	public class AirfieldShallowDTO
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
