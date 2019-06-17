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

		public async Task<Flight> GetAsync(Guid id)
		{
			return await _context.Flights
				.Include(ent => ent.Pilot)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff)
				.Include(ent => ent.Log).ThenInclude(ent => ent.Entries)
				.SingleAsync(ent => ent.ID.Equals(id));
		}
	}
}
