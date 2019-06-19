using System;
using Trial_Task_Model.Enumerations;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="FlightBasicPilotOriginatedDTO" />
	/// </summary>
	public class FlightBasicPilotOriginatedDTO
	{
		public DateTime Date { get; set; }

		public Guid ID { get; set; }

		public GPSLogBasicDTO Log { get; set; }

		public EFlightStatus Status { get; set; }
	}
}
