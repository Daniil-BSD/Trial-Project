using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="GPSLogShallowDTO" />
	/// </summary>
	public class GPSLogShallowDTO
	{
		public TimeSpan Duration { get; set; }

		public LinkedList<GPSLogEntryDTO> Entries { get; set; }

		public Guid ID { get; set; }

		public AirfieldBasicDTO PlaceOfLanding { get; set; }

		public AirfieldBasicDTO PlaceOfTakeoff { get; set; }
	}
}
