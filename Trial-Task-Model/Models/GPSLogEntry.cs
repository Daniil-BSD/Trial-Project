using System;
using System.Collections.Generic;
using Trial_Task_Model.Interfaces;

namespace Trial_Task_Model.Models
{
	/// <summary>
	/// Defines the <see cref="GPSLogEntry" /> data structure.
	/// </summary>
	public class GPSLogEntry : IGlobalPoint
	{
		public double Latitude { get; set; }

		public GPSLog Log { get; set; }

		public Guid LogID { get; set; }

		public double Longitude { get; set; }

		public DateTime Time { get; set; }

		/// <summary>
		/// The ParseFixRecord is a method that is accepting <see cref="string"/> from an IGC file.
		/// (uses a default date for time parameter)
		/// (Ignores the hemisphere making it valid only for logs within europe)
		/// </summary>
		/// <param name="record">The record<see cref="string"/>; acceptable format: "B1149444729375N01854784EA001680022200800400668153-0002"</param>
		/// <returns>The <see cref="GPSLogEntry"/>or null if Unparsable </returns>
		/// NOTE: it returns Null rather then Exception in order to enable parsing the whole IGC file line-by-line where only around 90% of lines are valid records.
		public static GPSLogEntry ParseFixRecord(string record)
		{
			return ParseFixRecord(record, new DateTime(2010, 1, 1, 0, 0, 0));
		}
		/// <summary>
		/// The ParseFixRecord is a method that is accepting <see cref="string"/> from an IGC file.
		/// (Ignores the hemisphere making it valid only for logs within europe)
		/// </summary>
		/// <param name="record">The record<see cref="string"/>; acceptable format: "B1149444729375N01854784EA001680022200800400668153-0002"</param>
		/// <param name="date">The Date to be given to this record(<see cref="DateTime"/>)</param>
		/// <returns>The <see cref="GPSLogEntry"/>or null if Unparsable </returns>
		/// NOTE: it returns Null rather then Exception in order to enable parsing the whole IGC file line-by-line where only around 90% of lines are valid records.
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
						(double.Parse(record.Substring(9, 5)) / 60000),
						Longitude =
						int.Parse(record.Substring(15, 3)) +
						(double.Parse(record.Substring(18, 5)) / 60000)
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

		/// <summary>
		/// Performs <see cref="ParseFixRecord(string)"/> on all valid strings.
		/// </summary>
		/// <param name="records">The records as <see cref="IEnumerable{string}"/></param>
		/// <returns>The <see cref="List{GPSLogEntry}"/>generated from the records.</returns>
		public static List<GPSLogEntry> ParseFixRecords(IEnumerable<string> records)
		{
			return ParseFixRecords(records, new DateTime(2010, 1, 1, 0, 0, 0));
		}

		/// <summary>
		/// Performs <see cref="ParseFixRecord(string, DateTime)"/> on all valid strings.
		/// </summary>
		/// <param name="records">The records as <see cref="IEnumerable{string}"/></param>
		/// <param name="date">The Date to be given to this record(<see cref="DateTime"/>)</param>
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
