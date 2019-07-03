using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="GPSLogShallowDTO" />
	/// </summary>
	public class GPSLogShallowDTO
	{
		public double ApproxLength { get; set; }

		public TimeSpan Duration { get; set; }

		public List<GPSLogEntryDTO> Entries { get; set; }

		public Guid ID { get; set; }

		public AirfieldBasicDTO PlaceOfLanding { get; set; }

		public AirfieldBasicDTO PlaceOfTakeoff { get; set; }

		public double RegisteredLength { get; set; }
	}
}
