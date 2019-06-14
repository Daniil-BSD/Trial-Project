using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Repositories;
using Trial_Task.Persistence.Contexts;

namespace Trial_Task.Persistence.Repositories
{
	public class GPSLogEntryRepository : BaseRepository, IGPSLogEntryRepository
	{
		public GPSLogEntryRepository(AppDbContext context) : base(context) { }

		public async Task<IEnumerable<GPSLogEntry>> ListAsync(Guid id)
		{
			return await _context.GPSLogEntries
			.Where(ent => ent.LogID.Equals(id))
			.ToListAsync();
		}
	}
}
