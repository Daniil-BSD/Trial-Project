using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	public class GPSLogShallowDTO
	{
		public Guid ID { get; set; }
		public LinkedList<GPSLogEntryDTO> Entries { get; set; }
		public TimeSpan Duration { get; set; }
		public AirfieldBasicDTO PlaceOfTakeoff { get; set; }
		public AirfieldBasicDTO PlaceOfLanding { get; set; }
	}
}
