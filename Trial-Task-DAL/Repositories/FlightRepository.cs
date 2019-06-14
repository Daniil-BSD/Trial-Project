using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task_DAL.Contexts;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.Repositories
{
	public class FlightRepository : BaseRepository, IFlightRepository
	{
		public FlightRepository(AppDbContext context) : base(context) { }

		public async Task<IEnumerable<Flight>> ListAsync()
		{
			return await _context.Flights
				.Include(ent => ent.Pilot)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff)
				.Include(ent => ent.Log).ThenInclude(ent => ent.Entries)
				.ToListAsync();
		}

		public async Task<Flight> GetAsync(Guid id)
		{
			return await _context.Flights
				.Include(ent => ent.Pilot)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff)
				.Include(ent => ent.Log).ThenInclude(ent => ent.Entries)
				.SingleOrDefaultAsync(ent => ent.ID.Equals(id));
		}

		public async Task<IEnumerable<Flight>> ListReducedAsync()
		{
			return await _context.Flights
				.Include(ent => ent.Pilot)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff)
				.ToListAsync();
		}
	}
}
