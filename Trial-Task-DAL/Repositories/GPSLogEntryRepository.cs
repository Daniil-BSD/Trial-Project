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
	/// Missing method summeries coould be found in <see cref="IGPSLogEntryRepository"/>
	/// </summary>
	public class GPSLogEntryRepository : BaseRepository<GPSLogEntry>, IGPSLogEntryRepository
	{
		public GPSLogEntryRepository(AppDbContext context) : base(context)
		{
		}

		public Task<List<GPSLogEntry>> ListAsync(Guid id)
		{
			return _context.GPSLogEntries
			.Where(ent => ent.LogID.Equals(id))
			.ToListAsync();
		}

		protected override IQueryable<GPSLogEntry> GetFullIncludes()
		{
			throw new NotImplementedException();
		}

		protected override IQueryable<GPSLogEntry> GetNoIncludes()
		{
			throw new NotImplementedException();
		}

		protected override IQueryable<GPSLogEntry> GetStandartIncludes()
		{
			throw new NotImplementedException();
		}
	}
}
