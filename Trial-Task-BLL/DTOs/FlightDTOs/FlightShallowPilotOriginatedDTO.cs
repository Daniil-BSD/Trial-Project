using System;
using Trial_Task_Model.Enumerations;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="FlightShallowPilotOriginatedDTO" />
	/// </summary>
	public class FlightShallowPilotOriginatedDTO
	{
		public DateTime Date { get; set; }

		public Guid ID { get; set; }

		public GPSLogShallowDTO Log { get; set; }

		public EFlightStatus Status { get; set; }
	}
}
