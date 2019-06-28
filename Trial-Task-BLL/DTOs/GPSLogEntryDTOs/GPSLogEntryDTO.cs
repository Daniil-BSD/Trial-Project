using System;
using System.Collections.Generic;

namespace Trial_Task_BLL.DTOs
{
	/// <summary>
	/// Defines the <see cref="GPSLogEntryDTO" />
	/// </summary>
	public class GPSLogEntryDTO
	{
		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public DateTime Time { get; set; }
	}

	/// <summary>
	/// Defines the <see cref="GPSLogEntryDTOExpansion" />
	/// </summary>
	public static class GPSLogEntryDTOExpansion
	{
		public static string ToJSString(this IList<GPSLogEntryDTO> list, bool longLat = true)
		{
			string ret = "[";
			for (int i = 0 ; i < list.Count ; i++)
			{
				if (longLat)
					ret += "[" + list[i].Longitude.Format() + "," + list[i].Latitude.Format() + "],";
				else
					ret += "[" + list[i].Latitude.Format() + "," + list[i].Longitude.Format() + "],";
			}
			return ret.Remove(ret.Length - 1) + "]";
		}

		private static string Format(this double d)
		{
			if (d < 100)
				return d.ToString("00.00000").Replace(",", ".");
			return d.ToString("000.0000").Replace(",", ".");
		}
	}
}
