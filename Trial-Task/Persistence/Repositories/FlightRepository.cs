using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Repositories;
using Trial_Task.Persistence.Contexts;

namespace Trial_Task.Persistence.Repositories
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

		public async Task<Flight> ListGet(Guid id)
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
