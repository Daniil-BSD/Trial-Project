using System;

namespace Trial_Task_Model.Interfaces
{
	/// <summary>
	/// Structure that Could be used as a standalone property instead of implementing <see cref="IGlobalPoint"/>.
	/// Also Implements all the static methods meant for the <see cref="IGlobalPoint"/>, like distance measurement.
	/// </summary>
	public struct GlobalPoint : IGlobalPoint
	{
		public double Latitude { get; set; }

		public double Longitude { get; set; }

		/// <summary>
		/// The Distance between two points.
		/// </summary>
		/// <param name="start">First <see cref="IGlobalPoint"/> point.</param>
		/// <param name="end">Second <see cref="IGlobalPoint"/> point.</param>
		/// <returns>The number of meters between two points as <see cref="double"/></returns>
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
