using System;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="GPSLogStandaloneListDTO" />
	/// </summary>
	public class GPSLogStandaloneListDTO
	{
		public double ApproxLength { get; set; }

		public TimeSpan Duration { get; set; }

		public FlightLogOriginatedDTO Flight { get; set; }

		public Guid ID { get; set; }

		public AirfieldShallowDTO PlaceOfLanding { get; set; }

		public AirfieldShallowDTO PlaceOfTakeoff { get; set; }

		public double RegisteredLength { get; set; }
	}
}
