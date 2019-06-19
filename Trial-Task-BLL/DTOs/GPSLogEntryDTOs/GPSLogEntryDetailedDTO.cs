using System;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="GPSLogEntryDetailedDTO" />
	/// </summary>
	public class GPSLogEntryDetailedDTO
	{
		public double Latitude { get; set; }

		public GPSLogDTO Log { get; set; }

		public double Longitude { get; set; }

		public DateTime Time { get; set; }
	}
}
