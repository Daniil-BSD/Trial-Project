using System;

namespace Trial_Task_BLL.DTOs
{
	public class GPSLogBasicDTO
	{
		public Guid ID { get; set; }
		public TimeSpan Duration { get; set; }
		public AirfieldBasicDTO PlaceOfTakeoff { get; set; }
		public AirfieldBasicDTO PlaceOfLanding { get; set; }
	}
}
