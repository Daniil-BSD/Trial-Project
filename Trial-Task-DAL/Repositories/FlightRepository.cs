using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task_DAL.Contexts;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.Repositories
{
	/// <summary>
	/// Defines the <see cref="FlightRepository" />
	/// </summary>
	public class FlightRepository : BaseRepository, IFlightRepository
	{
		public FlightRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<Flight> GetAsync(Guid id)
		{
			return await _context.Flights
				.Include(ent => ent.Pilot)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff)
				.Include(ent => ent.Log).ThenInclude(ent => ent.Entries)
				.SingleAsync(ent => ent.ID.Equals(id));
		}

		public async Task<Flight> InsertNewFlight(Flight flightIn)
		{
			if (flightIn.Log != null)
			{
				using (var transaction = _context.Database.BeginTransaction())
				{
					var log = _context.GPSLogs.Add(flightIn.Log);
					_context.SaveChanges();
					var logID = log.Entity.ID;
					foreach (var entry in flightIn.Log.Entries)
					{
						entry.LogID = logID;
						entry.Log = null;
					}
					_context.GPSLogEntries.AddRange(flightIn.Log.Entries);
					_context.SaveChanges();
					flightIn.LogID = logID;
					var flightOut = _context.Flights.Add(flightIn);
					_context.SaveChanges();
					transaction.Commit();
					return await GetAsync(flightOut.Entity.ID);
				}
			} else
			{
				throw new ArgumentNullException("flight.Log");
			}
		}

		public Task<List<Flight>> ListAsync()
		{
			return _context.Flights
				.Include(ent => ent.Pilot)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff)
				.Include(ent => ent.Log).ThenInclude(ent => ent.Entries)
				.ToListAsync();
		}

		public Task<List<Flight>> ListReducedAsync()
		{
			return _context.Flights
				.Include(ent => ent.Pilot)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff)
				.ToListAsync();
		}
	}
}
