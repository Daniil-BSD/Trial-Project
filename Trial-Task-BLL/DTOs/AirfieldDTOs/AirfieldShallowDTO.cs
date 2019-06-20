using System;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="AirfieldShallowDTO" />
	/// </summary>
	public class AirfieldShallowDTO
	{
		public Guid ID { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public string Name { get; set; }
	}
}
