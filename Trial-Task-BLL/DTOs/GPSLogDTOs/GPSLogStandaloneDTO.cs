using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	public class GPSLogStandaloneDTO
	{
		public Guid ID { get; set; }
		public FlightLogOriginatedDTO Flight { get; set; }
		public LinkedList<GPSLogEntryDTO> Entries { get; set; }
		public TimeSpan Duration { get; set; }
		public AirfieldShallowDTO PlaceOfTakeoff { get; set; }
		public AirfieldShallowDTO PlaceOfLanding { get; set; }
	}
}
