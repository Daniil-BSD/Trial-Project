using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Trial_Task.Domain.Models
{
    public class User //: IdentityUser
    {
        public Guid Guid_ID { get; set; }
		public ICollection<Flight> Flights { get; set; }
	}
}
