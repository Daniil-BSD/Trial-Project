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
	/// Defines the <see cref="UserRepository" />
	/// </summary>
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(AppDbContext context) : base(context)
		{
		}

		public Task<User> GetAsync(Guid id)
		{
			return GetStandartIncludes()
				.SingleOrDefaultAsync(ent => ent.Id.Equals(id));
		}

		public Task<User> GetFullAsync(Guid id)
		{
			return GetFullIncludes()
				.SingleOrDefaultAsync(ent => ent.Id.Equals(id));
		}

		public Task<List<User>> ListAsync()
		{
			return GetStandartIncludes()
				.ToListAsync();
		}

		public Task<List<User>> ListShallowAsync()
		{
			return GetNoIncludes()
				.ToListAsync();
		}

		protected override IQueryable<User> GetFullIncludes()
		{
			return _context.Users
				.Include(ent => ent.Flights).ThenInclude(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Flights).ThenInclude(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff)
				.Include(ent => ent.Flights).ThenInclude(ent => ent.Log).ThenInclude(ent => ent.Entries);
		}

		protected override IQueryable<User> GetNoIncludes()
		{
			return _context.Users;
		}

		protected override IQueryable<User> GetStandartIncludes()
		{
			return _context.Users
				   .Include(ent => ent.Flights).ThenInclude(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				   .Include(ent => ent.Flights).ThenInclude(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff);
		}
	}
}
