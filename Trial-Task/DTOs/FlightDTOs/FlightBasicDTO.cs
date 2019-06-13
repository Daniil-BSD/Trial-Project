using System;
using Trial_Task.Domain.Enumerations;

namespace Trial_Task.DTOs
{
	public class FlightBasicDTO
	{
		public Guid ID { get; set; }
		public DateTime Date { get; set; }
		public EFlightStatus Status { get; set; }
		public GPSLogBasicDTO Log { get; set; }
		public UserBasicDTO Pilot { get; set; }
	}
}
