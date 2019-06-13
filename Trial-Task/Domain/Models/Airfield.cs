using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trial_Task.Domain.Models
{
    public class Airfield
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

		public ICollection<GPSLog> StartFrom { get; set; }
		public ICollection<GPSLog> EndedAt { get; set; }
	}
}
