using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="GPSLogDTO" />
	/// </summary>
	public class GPSLogDTO
	{
		public TimeSpan Duration { get; set; }

		public List<GPSLogEntryDTO> Entries { get; set; }

		public Guid ID { get; set; }

		public AirfieldShallowDTO PlaceOfLanding { get; set; }

		public AirfieldShallowDTO PlaceOfTakeoff { get; set; }
	}
}
