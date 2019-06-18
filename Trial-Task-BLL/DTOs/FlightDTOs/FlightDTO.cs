using System;
using Trial_Task_Model.Enumerations;

namespace Trial_Task_BLL.DTOs
{
	public class FlightDTO
	{
		public Guid ID { get; set; }
		public DateTime Date { get; set; }
		public EFlightStatus Status { get; set; }
		public GPSLogDTO Log { get; set; }
		public UserBasicDTO Pilot { get; set; }
	}
}
