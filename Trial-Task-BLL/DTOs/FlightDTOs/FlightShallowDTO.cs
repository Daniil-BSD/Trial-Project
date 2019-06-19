using System;
using Trial_Task_Model.Enumerations;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="FlightShallowDTO" />
	/// </summary>
	public class FlightShallowDTO
	{
		public DateTime Date { get; set; }

		public Guid ID { get; set; }

		public GPSLogShallowDTO Log { get; set; }

		public UserShallowDTO Pilot { get; set; }

		public EFlightStatus Status { get; set; }
	}
}
