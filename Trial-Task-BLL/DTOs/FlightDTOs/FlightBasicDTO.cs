using System;
using Trial_Task_Model.Enumerations;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="FlightBasicDTO" />
	/// </summary>
	public class FlightBasicDTO
	{
		public DateTime Date { get; set; }

		public Guid ID { get; set; }

		public GPSLogBasicDTO Log { get; set; }

		public UserBasicDTO Pilot { get; set; }

		public EFlightStatus Status { get; set; }
	}
}
