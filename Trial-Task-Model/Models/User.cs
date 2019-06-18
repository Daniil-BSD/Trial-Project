using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Trial_Task_Model.Models
{
	public class User : IdentityUser<Guid>
	{
		public ICollection<Flight> Flights { get; set; }
	}
}
