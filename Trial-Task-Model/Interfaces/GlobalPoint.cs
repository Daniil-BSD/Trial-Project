using System;
using System.Collections.Generic;
using System.Text;

namespace Trial_Task_Model.Interfaces
{
	public abstract class GlobalPoint : IGlobalPoint
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public static double Distance(IGlobalPoint start, IGlobalPoint end)
		{
			double rlat1 = Math.PI * start.Latitude / 180;
			double rlat2 = Math.PI * end.Latitude / 180;
			double theta = start.Longitude - end.Longitude;
			double rtheta = Math.PI * theta / 180;
			double dist =
				Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
				Math.Cos(rlat2) * Math.Cos(rtheta);
			dist = Math.Acos(dist);
			dist = dist * 180 / Math.PI;
			dist = dist * 60 * 1.1515;

			return dist * 1609.344;
		}
	}
}
