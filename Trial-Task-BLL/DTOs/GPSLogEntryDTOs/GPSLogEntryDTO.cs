using System;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="GPSLogEntryDTO" />
	/// </summary>
	public class GPSLogEntryDTO
	{
		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public DateTime Time { get; set; }
	}
}
