using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	public class GPSLogDTO
	{
		public Guid ID { get; set; }
		public LinkedList<GPSLogEntryDTO> Entries { get; set; }
		public TimeSpan Duration { get; set; }
		public AirfieldShallowDTO PlaceOfTakeoff { get; set; }
		public AirfieldShallowDTO PlaceOfLanding { get; set; }
	}
}
