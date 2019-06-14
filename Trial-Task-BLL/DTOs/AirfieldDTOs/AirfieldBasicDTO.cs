using System;

namespace Trial_Task_BLL.DTOs
{

	/*
		Contains only Name and ID, could be used for the reduction of traffic, for cases when name would be enough.
	*/
	public class AirfieldBasicDTO
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
	}
}
