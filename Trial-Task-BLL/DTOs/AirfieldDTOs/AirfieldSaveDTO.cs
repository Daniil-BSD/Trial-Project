using System.ComponentModel.DataAnnotations;

namespace Trial_Task_BLL.DTOs
{
	/*
	*	DTO for adding a new airfield.
	*/
	public class AirfieldSaveDTO
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public double Latitude { get; set; }
		[Required]
		public double Longitude { get; set; }
	}
}
