using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.Responses;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Interfaces;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Services
{
	/// <summary>
	/// Defines the <see cref="FlightService" />
	/// </summary>
	public class FlightService : BaseService, IFlightService
	{
		private readonly IFlightRepository _flightRepository;

		private readonly IGPSLogService _gpsLogService;

		private readonly IUserService _userService;

		public FlightService(IFlightRepository flightRepository, IGPSLogService gpsLogService, IUserService userService, IMapper mapper) : base(mapper)
		{
			_gpsLogService = gpsLogService;
			_flightRepository = flightRepository;
			_userService = userService;
		}

		/// <summary>
		/// Performs <see cref="ParseFixRecord(string)"/> on all valid strings.
		/// </summary>
		/// <param name="records">The records as <see cref="IList{string}"/></param>
		/// <returns>The <see cref="List{GPSLogEntry}"/>generated from the records.</returns>
		public static List<GPSLogEntry> ParseFixRecords(IList<string> records)
		{
			List<GPSLogEntry> ret = new List<GPSLogEntry>();
			string str = records[1];
			DateTime date = new DateTime(
				2000 + int.Parse(str.Substring(9, 2)),
				int.Parse(str.Substring(7, 2)),
				int.Parse(str.Substring(5, 2))
				);
			foreach (string record in records)
			{
				var temp = GPSLogEntry.ParseFixRecord(record, date);
				if (temp != null)
				{
					ret.Add(temp);
				}
			}
			var aprFixes = GetApproximatingNodes(ret);
			foreach (var fix in aprFixes)
			{
				fix.ApproximatingFix = true;
			}
			return ret;
		}

		/// <summary>
		/// Performs <see cref="ParseFixRecord(string, DateTime)"/> on all valid strings.
		/// </summary>
		/// <param name="records">The records as <see cref="IList{string}"/></param>
		/// <param name="date">The Date to be given to this record(<see cref="DateTime"/>)</param>
		public static List<GPSLogEntry> ParseFixRecords(IList<string> records, DateTime date)
		{
			List<GPSLogEntry> ret = new List<GPSLogEntry>();
			foreach (string str in records)
			{
				var temp = GPSLogEntry.ParseFixRecord(str, date);
				if (temp != null)
				{
					ret.Add(temp);
				}
			}
			return ret;
		}

		public async Task<Response<FlightDTO>> GetAsync(Guid id)
		{
			var task = _flightRepository.GetAsync(id);
			return await Response<FlightDTO>.CatchInvalidOperationExceptionAndMap(task, _mapper);
		}

		public async Task<Response<FlightBasicDTO>> GetBasicAsync(Guid id)
		{
			var task = _flightRepository.GetBasicAsync(id);
			return await Response<FlightBasicDTO>.CatchInvalidOperationExceptionAndMap(task, _mapper);
		}

		public async Task<List<FlightBasicDTO>> ListReducedAsync()
		{
			var flights = await _flightRepository.ListReducedAsync();
			return _mapper.Map<List<Flight>, List<FlightBasicDTO>>(flights);
		}

		public async Task<Response<FlightDTO>> ParseIGCFile(string path)
		{
			var userIDResponse = _userService.GetCurrentUserID();
			if (!userIDResponse.Success)
				return new Response<FlightDTO>(userIDResponse);
			return await ParseIGCFile(path, userIDResponse.Value);
		}

		public async Task<Response<FlightDTO>> ParseIGCFile(string path, Guid userID)
		{
			List<GPSLogEntry> entries = ParseFixRecords(System.IO.File.ReadAllLines(path));
			Flight flight = new Flight()
			{
				Log = await _gpsLogService.ParseGPSLogEntries(entries),
				Status = Trial_Task_Model.Enumerations.EFlightStatus.Pending,
				UserID = userID,
				Date = entries[0].Time
			};
			return await Response<FlightDTO>.CatchInvalidOperationExceptionAndMap(_flightRepository.InsertNewFlight(flight), _mapper);
		}

		public async Task<Response<FlightBasicDTO>> UpdaateStatus(FlightStatusUpdateDTO flightStatusUpdateDTO)
		{
			var userIDResponse = _userService.GetCurrentUserID();
			if (!userIDResponse.Success)
				return new Response<FlightBasicDTO>(userIDResponse);
			var flight = _flightRepository.UpdateStatusAsync(flightStatusUpdateDTO.Target, flightStatusUpdateDTO.Status);
			return await Response<FlightBasicDTO>.CatchInvalidOperationExceptionAndMap(flight, _mapper);
		}

		private static List<GPSLogEntry> GetApproximatingNodes(List<GPSLogEntry> fullSet, int targetCount = 7)
		{
			const double step = 0.0001; // the stemp by which bioas is incremented.
			const int minModificationsPerRun = 20; // allows to increase bias even if modifications were performed.
			int strictBiasBound = targetCount * 16; // defines the bound after which optimisations are removed

			List<GPSLogEntry> a, b;
			a = fullSet;
			b = new List<GPSLogEntry>(fullSet.Count);
			int modified = 0;
			double bias = 0;
			double sum = 0;
			double avg = 1;

			while (a.Count > targetCount)
			{
				//Console.WriteLine(a.Count + "  bias: " + bias + " avg: " + avg);
				b.Add(a[0]);
				for (int i = 1 ; i < a.Count - 1 ; i++)
				{
					double A = GlobalPoint.Distance(a[i - 1], a[i]);// distancec too previus node
					double B = GlobalPoint.Distance(a[i + 1], a[i]);// distance to the next node
					double C = GlobalPoint.Distance(a[i - 1], a[i + 1]);// distance between neighbouring nodes
																		//removes nodes with the least impact on total length (favours removal of nodes with nodes closer than average)
					if (A + B <= C * (1 + bias * (avg / C)))
					{
						modified++;
						i++;
						b.Add(a[i]);
						sum += C;
					} else
					{
						b.Add(a[i]);
						sum += A;
					}
				}
				if (!b[b.Count - 1].Equals(a[a.Count - 1]))
					b.Add(a[a.Count - 1]);

				if (modified < minModificationsPerRun && (b.Count > strictBiasBound || modified <= 1))
				{
					bias += step;
				} else
				{
					modified = 0;
				}
				//formula works better if avg value is less than true average; Mhen list is small, correction for length is too great, thus avg value is locked at final stages
				avg = (a.Count >= strictBiasBound) ? (avg + avg + (sum / b.Count)) / 3 : avg;
				a = b;
				b = new List<GPSLogEntry>(a.Count);
			}
			return a;
		}
	}
}
