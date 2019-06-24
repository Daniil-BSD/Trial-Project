using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Trial_Task_Model.Models
{
	/// <summary>
	/// Defines the <see cref="User" /> data structure.
	/// </summary>
	public class User : IdentityUser<Guid>
	{
		public ICollection<Flight> Flights { get; set; }
	}
}
