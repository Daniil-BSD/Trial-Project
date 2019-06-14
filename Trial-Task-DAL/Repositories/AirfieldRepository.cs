using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task_DAL.Contexts;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

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
	}
}
