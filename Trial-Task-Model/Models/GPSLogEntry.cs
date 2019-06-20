using System;
using System.Collections.Generic;
using Trial_Task_Model.Interfaces;

namespace Trial_Task_Model.Models
{
	/// <summary>
	/// Defines the <see cref="GPSLogEntry" />
	/// </summary>
	public class GPSLogEntry : IGlobalPoint
	{
		public double Latitude { get; set; }

		//Computed
		public GPSLog Log { get; set; }

		//Stored
		public Guid LogID { get; set; }

		public double Longitude { get; set; }

		public DateTime Time { get; set; }

		public static GPSLogEntry ParseFixRecord(string record)
		{
			return ParseFixRecord(record, new DateTime(2010, 1, 1, 0, 0, 0));
		}

		public static GPSLogEntry ParseFixRecord(string record, DateTime date)
		{
			try
			{
				if (record[0] == 'B')
				{
					GPSLogEntry ret = new GPSLogEntry()
					{
						Time = new DateTime(
						date.Year,
						date.Month,
						date.Day,
						int.Parse(record.Substring(1, 2)),
						int.Parse(record.Substring(3, 2)),
						int.Parse(record.Substring(5, 2))
						),
						Latitude =
						int.Parse(record.Substring(7, 2)) +
						(60000 / (double.Parse(record.Substring(9, 5)))),
						Longitude =
						int.Parse(record.Substring(15, 3)) +
						(60000 / (double.Parse(record.Substring(18, 5))))
					};
					return ret;
				}
				return null;
			}
			catch (IndexOutOfRangeException)
			{
				return null;
			}
		}

		public static List<GPSLogEntry> ParseFixRecords(IEnumerable<string> records)
		{
			return ParseFixRecords(records, new DateTime(2010, 1, 1, 0, 0, 0));
		}

		public static List<GPSLogEntry> ParseFixRecords(IEnumerable<string> records, DateTime date)
		{
			List<GPSLogEntry> ret = new List<GPSLogEntry>();
			foreach (string str in records)
			{
				var temp = ParseFixRecord(str, date);
				if (temp != null)
				{
					ret.Add(temp);
				}
			}
			return ret;
		}
	}
}
