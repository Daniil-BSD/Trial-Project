using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task_DAL.Contexts;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model;
using Trial_Task_Model.Interfaces;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.Repositories
{
	/// <summary>
	/// Defines the <see cref="AirfieldRepository" />
	/// Missin method summeries coould be found in <see cref="IAirfieldRepository"/>
	/// </summary>
	public class AirfieldRepository : BaseRepository<Airfield>, IAirfieldRepository
	{
		public AirfieldRepository(AppDbContext context) : base(context)
		{
		}

		public Task<List<Airfield>> FilterListAsync(Expression<Func<Airfield, bool>> func)
		{
			return GetFullIncludes()
				.Where(func)
				.ToListAsync();
		}

		public Task<List<Airfield>> FilterListShallowAsync(Expression<Func<Airfield, bool>> func)
		{
			return GetNoIncludes()
				.Where(func)
				.ToListAsync();
		}

		public Task<Airfield> FindAround(IGlobalPoint globalPoint)
		{
			return GetFullIncludes()
				.SingleAsync(ent => GlobalPoint.Distance(ent, globalPoint) <= Constants.AIRFIELD_DESIGNATED_AREA_RADIUS);
		}

		public Task<Airfield> GetAsync(Guid id)
		{
			return GetFullIncludes()
				.SingleAsync(ent => ent.ID.Equals(id));
		}

		public Task<Airfield> GetRowAsync(Guid id)
		{
			return _context.Airfields
				.SingleAsync(ent => ent.ID == id);
		}

		public Task<Airfield> GetShallowAsync(Guid id)
		{
			return GetNoIncludes()
				.SingleAsync(ent => ent.ID == id);
		}

		public Task<List<Airfield>> ListAsync()
		{
			return GetFullIncludes()
				.ToListAsync();
		}

		public Task<List<Airfield>> ListShallowAsync()
		{
			return GetNoIncludes()
				.ToListAsync();
		}

		public async Task<Airfield> UnvalidatedInsertAsync(Airfield airfield)
		{
			var ret = _context.Airfields.Add(airfield);
			await _context.SaveChangesAsync();
			return ret.Entity;
		}

		/// <summary>
		/// A single point for managing full includes (meaning loading all the rows required by the most extensive DTO)
		/// (marked with [MethodImpl(MethodImplOptions.AggressiveInlining)])
		/// </summary>
		/// <returns>The <see cref="IQueryable{Airfield}"/> that could b expanded upon</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override IQueryable<Airfield> GetFullIncludes()
		{
			return _context.Airfields
				.Include(ent => ent.StartFrom).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.EndedAt).ThenInclude(ent => ent.PlaceOfTakeoff);
		}

		/// <summary>
		/// A single point for managing minimal includes (none), in case some additiona includes or filters have to be added in every minimal request.
		/// (marked with [MethodImpl(MethodImplOptions.AggressiveInlining)])
		/// </summary>
		/// <returns>The <see cref="IQueryable{Airfield}"/> that could b expanded upon</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override IQueryable<Airfield> GetNoIncludes()
		{
			return _context.Airfields;
		}

		/// <summary>
		/// A single point for managing default includes (meaning loading all the rows required by the standart DTOs)
		/// (marked with [MethodImpl(MethodImplOptions.AggressiveInlining)])
		/// </summary>
		/// <returns>The <see cref="IQueryable{Airfield}"/> that could b expanded upon</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override IQueryable<Airfield> GetStandartIncludes()
		{
			return _context.Airfields
				.Include(ent => ent.StartFrom)
				.Include(ent => ent.EndedAt);
		}
	}
}
