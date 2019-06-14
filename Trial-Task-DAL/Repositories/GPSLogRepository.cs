using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task_DAL.Contexts;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.Repositories
{
	public class GPSLogRepository : BaseRepository, IGPSLogRepository
	{
		public GPSLogRepository(AppDbContext context) : base(context) { }


		/*
		 * Standart log request. (flight not included)
		 */
		public async Task<GPSLog> GetAsync(Guid id)
		{
			return await _context.GPSLogs
				.Include(ent => ent.Entries)
				.Include(ent => ent.PlaceOfLanding)
				.Include(ent => ent.PlaceOfTakeoff)
				.SingleOrDefaultAsync(ent => ent.ID.Equals(id));
		}

		/*
		 * Detailed log request, additionaly includes the assosiated flight and the pilot.
		 */
		public async Task<GPSLog> GetFullAsync(Guid id)
		{
			return await _context.GPSLogs
				.Include(ent => ent.Entries)
				.Include(ent => ent.Flight).ThenInclude(ent => ent.Pilot)
				.Include(ent => ent.PlaceOfLanding)
				.Include(ent => ent.PlaceOfTakeoff)
				.SingleOrDefaultAsync(ent => ent.ID.Equals(id));
		}

		/*
		 * Standart list of all logs (not including data form the flight)
		 */
		public async Task<IEnumerable<GPSLog>> ListAsync()
		{
			return await _context.GPSLogs
				.Include(ent => ent.Entries)
				.Include(ent => ent.PlaceOfLanding)
				.Include(ent => ent.PlaceOfTakeoff)
				.ToListAsync();
		}

		/*
		 * Reurns Only basic information, including only the endpoints (the entries are not loaded)
		 */
		public async Task<IEnumerable<GPSLog>> ListReducedAsync()
		{
			return await _context.GPSLogs
				.Include(ent => ent.PlaceOfLanding)
				.Include(ent => ent.PlaceOfTakeoff)
				.ToListAsync();
		}


		/*
		 * Reurns all the assosiated daata with the log, like the flight and the pilot
		 * (data is equvivalent to FlightRepository.ListAsync() at the moment, but it could change given the possability of 
		 * expantion of the flight with other sortds of logs (like altitude log))
		 */
		public async Task<IEnumerable<GPSLog>> ListStandaloneAsync()
		{
			return await _context.GPSLogs
				.Include(ent => ent.Entries)
				.Include(ent => ent.Flight).ThenInclude(ent => ent.Pilot)
				.Include(ent => ent.PlaceOfLanding)
				.Include(ent => ent.PlaceOfTakeoff)
				.ToListAsync();
		}
	}
}
