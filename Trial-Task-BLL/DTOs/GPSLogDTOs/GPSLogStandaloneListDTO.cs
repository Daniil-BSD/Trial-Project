using System;

namespace Trial_Task_BLL.DTOs
{
	public class GPSLogStandaloneListDTO
	{
		public Guid ID { get; set; }
		public FlightLogOriginatedDTO Flight { get; set; }
		public TimeSpan Duration { get; set; }
		public AirfieldShallowDTO PlaceOfTakeoff { get; set; }
		public AirfieldShallowDTO PlaceOfLanding { get; set; }
	}
}
