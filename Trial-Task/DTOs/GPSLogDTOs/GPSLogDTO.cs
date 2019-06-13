using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trial_Task.DTOs
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
