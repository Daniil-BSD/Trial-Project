using System;

namespace Trial_Task_Model.Models
{
	/// <summary>
	/// Defines the <see cref="IGCFileRecord" />
	/// </summary>
	public class IGCFileRecord
	{
		public string FilePath { get; set; }

		public User Pilot { get; set; }

		public Guid UserID { get; set; }
	}
}
