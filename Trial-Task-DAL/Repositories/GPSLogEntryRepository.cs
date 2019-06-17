using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task_DAL.Contexts;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.Repositories
{
	/// <summary>
	/// Defines the <see cref="GPSLogEntryRepository" />
	/// </summary>
	public class GPSLogEntryRepository : BaseRepository, IGPSLogEntryRepository
	{
		public GPSLogEntryRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<GPSLogEntry>> ListAsync(Guid id)
		{
			return await _context.GPSLogEntries
			.Where(ent => ent.LogID.Equals(id))
			.ToListAsync();
		}
	}
}
