using System;
using Trial_Task_Model.Enumerations;

namespace Trial_Task_Model.Models
{
	public class Flight
	{
		//Stored
		public Guid ID { get; set; }
		public DateTime Date { get; set; }
		public EFlightStatus Status { get; set; }
		public Guid LogID { get; set; }
		public Guid UserID { get; set; }
		//Computed
		public GPSLog Log { get; set; }
		public User Pilot { get; set; }
	}
}
