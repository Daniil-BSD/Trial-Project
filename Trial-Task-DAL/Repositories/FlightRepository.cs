using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task_DAL.Contexts;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Enumerations;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.Repositories
{
	/// <summary>
	/// Defines the <see cref="FlightRepository" />
	/// Missin method summeries coould be found in <see cref="IFlightRepository"/>
	/// </summary>
	public class FlightRepository : BaseRepository<Flight>, IFlightRepository
	{
		public FlightRepository(AppDbContext context) : base(context)
		{
		}

		public Task<Flight> GetAsync(Guid id)
		{
			return GetFullIncludes()
				.SingleAsync(ent => ent.ID.Equals(id));
		}

		public Task<Flight> GetBasicAsync(Guid id)
		{
			return GetStandartIncludes()
				.SingleAsync(ent => ent.ID.Equals(id));
		}

		public Task<Flight> GetRowAsync(Guid id)
		{
			return _context.Flights.SingleAsync(ent => ent.ID.Equals(id));
		}

		/// <summary>
		/// Inserts a new <see cref="Flight"/> into the Database.
		/// Note that <see cref="Flight"/> has <see cref="Guid"/>field indecating <see cref="User"/> and includes <see cref="GPSLog"/> which includes multiple <see cref="GPSLogEntry"/>;
		/// all this data is inserted into the respective tables while properly linkingthe references, so <paramref name="flightIn"/> needs to have all those fields valid.
		/// </summary>
		/// <param name="flightIn">The <see cref="Flight"/> to be inserted.</param>
		/// <returns>The same <see cref="Task{Flight}"/>, returned as it was recorded in a database (ID field is now populated)</returns>
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
			return GetFullIncludes()
				.ToListAsync();
		}

		public Task<List<Flight>> ListReducedAsync()
		{
			return GetStandartIncludes()
				.ToListAsync();
		}

		public async Task<Flight> UpdateStatusAsync(Guid id, EFlightStatus status)
		{
			var flight = await GetRowAsync(id);
			flight.Status = status;
			var ent = _context.Flights.Update(flight);
			_context.SaveChanges();
			return ent.Entity;
		}

		/// <summary>
		/// A single point for managing full includes (meaning loading all the rows required by the most extensive DTO)
		/// (marked with [MethodImpl(MethodImplOptions.AggressiveInlining)])
		/// </summary>
		/// <returns>The <see cref="IQueryable{Flight}"/> that could b expanded upon</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override IQueryable<Flight> GetFullIncludes()
		{
			return _context.Flights
				.Include(ent => ent.Pilot)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff)
				.Include(ent => ent.Log).ThenInclude(ent => ent.Entries);
		}


		/// <summary>
		/// A single point for managing default includes (meaning loading all the rows required by the standart DTOs)
		/// (marked with [MethodImpl(MethodImplOptions.AggressiveInlining)])
		/// </summary>
		/// <returns>The <see cref="IQueryable{Flight}"/> that could b expanded upon</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override IQueryable<Flight> GetStandartIncludes()
		{
			return _context.Flights
				.Include(ent => ent.Pilot)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff);
		}

		/// <summary>
		/// A single point for managing minimal includes (none), in case some additiona includes or filters have to be added in every minimal request.
		/// (marked with [MethodImpl(MethodImplOptions.AggressiveInlining)])
		/// </summary>
		/// <returns>The <see cref="IQueryable{Airfield}"/> that could b expanded upon</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override IQueryable<Flight> GetNoIncludes()
		{
			return _context.Flights;
		}
	}
}
