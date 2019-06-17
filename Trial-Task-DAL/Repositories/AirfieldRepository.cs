using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task_DAL.Contexts;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Interfaces;
using Trial_Task_Model.Models;
using System.Linq;

namespace Trial_Task_DAL.Repositories
{
	public class AirfieldRepository : BaseRepository, IAirfieldRepository
	{
		public AirfieldRepository(AppDbContext context) : base(context) { }

		public async Task<Airfield> GetAsync(Guid id)
		{
			return await _context.Airfields
				.Include(ent => ent.StartFrom)
				.Include(ent => ent.EndedAt)
				.SingleOrDefaultAsync(ent => ent.ID.Equals(id));
		}

		public async Task<Airfield> GetShallowAsync(Guid id)
		{
			return await _context.Airfields
				.FindAsync(id);
		}

		public async Task<IEnumerable<Airfield>> ListAsync()
		{
			return await _context.Airfields
				.Include(ent => ent.StartFrom)
				.Include(ent => ent.EndedAt).ToListAsync();
		}

		public async Task<IEnumerable<Airfield>> ListShallowAsync()
		{
			return await _context.Airfields
				.ToListAsync();
		}

		public async Task<Airfield> InsertAsync(Airfield airfield)
		{
			var noCollision = _context.Airfields.Where(a => (GlobalPoint.Distance(a, airfield) < 3000)).Count() == 0;
			if (noCollision)
			{
				var ret = await _context.Airfields.AddAsync(airfield);
				await _context.SaveChangesAsync();
				return ret.Entity;
			} else {
				throw new ArgumentOutOfRangeException("Latitude, Longitude", "New airfield is to close to already registered one. ");
			}
		}
	}
}
