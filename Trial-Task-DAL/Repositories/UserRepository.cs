using System;
using System.Collections.Generic;
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
	public class UserRepository : BaseRepository, IUserRepository
	{
		public UserRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<User> GetAsync(Guid id)
		{
			return await _context.Users
				.Include(ent => ent.Flights).ThenInclude(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Flights).ThenInclude(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff)
				.SingleOrDefaultAsync(ent => ent.Id.Equals(id));
		}

		public async Task<User> GetFullAsync(Guid id)
		{
			return await _context.Users
				.Include(ent => ent.Flights).ThenInclude(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Flights).ThenInclude(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff)
				.Include(ent => ent.Flights).ThenInclude(ent => ent.Log).ThenInclude(ent => ent.Entries)
				.SingleOrDefaultAsync(ent => ent.Id.Equals(id));
		}

		public async Task<IEnumerable<User>> ListAsync()
		{
			return await _context.Users
				.Include(ent => ent.Flights).ThenInclude(ent => ent.Log).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.Flights).ThenInclude(ent => ent.Log).ThenInclude(ent => ent.PlaceOfTakeoff)
				.ToListAsync();
		}

		public async Task<IEnumerable<User>> ListShallowAsync()
		{
			return await _context.Users
				.ToListAsync();
		}
	}
}
