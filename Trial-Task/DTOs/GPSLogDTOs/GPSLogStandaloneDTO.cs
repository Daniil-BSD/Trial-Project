using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trial_Task.DTOs
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
