using System;
using System.Collections.Generic;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.DTOs
{
	/*
		A complete replica of the Airfield class, created to pivide a modification point and because there is no protected information in it
	*/
	public class AirfieldSaveDTO
	{
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
