using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task_DAL.Contexts;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.Repositories
{
	/// <summary>
	/// Defines the <see cref="GPSLogRepository" />
	/// Missin method summeries coould be found in <see cref="IGPSLogRepository"/>
	/// </summary>
	public class GPSLogRepository : BaseRepository<GPSLog>, IGPSLogRepository
	{
		public GPSLogRepository(AppDbContext context) : base(context)
		{
		}

		public Task<GPSLog> GetAsync(Guid id)
		{
			return GetStandartIncludes()
				.SingleAsync(ent => ent.ID.Equals(id));
		}


		public Task<GPSLog> GetFullAsync(Guid id)
		{
			return GetFullIncludes()
				.SingleAsync(ent => ent.ID.Equals(id));
		}

		public Task<GPSLog> GetRowAsync(Guid id)
		{
			return _context.GPSLogs.SingleAsync(ent => ent.ID.Equals(id));
		}


		public Task<List<GPSLog>> ListAsync()
		{
			return GetStandartIncludes()
				.ToListAsync();
		}


		public Task<List<GPSLog>> ListReducedAsync()
		{
			return GetNoIncludes()
				.ToListAsync();
		}


		public Task<List<GPSLog>> ListStandaloneAsync()
		{
			return GetFullIncludes()
				.ToListAsync();
		}


		/// <summary>
		/// A single point for managing full includes (meaning loading all the rows required by the most extensive DTO)
		/// (marked with [MethodImpl(MethodImplOptions.AggressiveInlining)])
		/// </summary>
		/// <returns>The <see cref="IQueryable{GPSLog}"/> that could b expanded upon</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override IQueryable<GPSLog> GetFullIncludes()
		{
			return _context.GPSLogs
				.Include(ent => ent.Entries)
				.Include(ent => ent.Flight).ThenInclude(ent => ent.Pilot)
				.Include(ent => ent.PlaceOfLanding)
				.Include(ent => ent.PlaceOfTakeoff);
		}


		/// <summary>
		/// A single point for managing default includes (meaning loading all the rows required by the standart DTOs)
		/// (marked with [MethodImpl(MethodImplOptions.AggressiveInlining)])
		/// </summary>
		/// <returns>The <see cref="IQueryable{GPSLog}"/> that could b expanded upon</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override IQueryable<GPSLog> GetStandartIncludes()
		{
			return _context.GPSLogs
				.Include(ent => ent.Entries)
				.Include(ent => ent.PlaceOfLanding)
				.Include(ent => ent.PlaceOfTakeoff);
		}

		/// <summary>
		/// A single point for managing minimal includes, in case some additiona includes or filters have to be added in every minimal request.
		/// (marked with [MethodImpl(MethodImplOptions.AggressiveInlining)])
		/// </summary>
		/// <returns>The <see cref="IQueryable{GPSLog}"/> that could b expanded upon</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override IQueryable<GPSLog> GetNoIncludes()
		{
			return _context.GPSLogs
				.Include(ent => ent.PlaceOfLanding)
				.Include(ent => ent.PlaceOfTakeoff);
		}
	}
}
