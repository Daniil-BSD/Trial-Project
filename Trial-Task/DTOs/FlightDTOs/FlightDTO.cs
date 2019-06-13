using System;
using Trial_Task.Domain.Enumerations;

namespace Trial_Task.DTOs
{
	public class FlightDTO
	{
		public Guid ID { get; set; }
		public DateTime Date { get; set; }
		public EFlightStatus Status { get; set; }
		public GPSLogDTO Log { get; set; }
		public UserDTO Pilot { get; set; }
	}
}
