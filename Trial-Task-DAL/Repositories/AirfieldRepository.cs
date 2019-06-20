using System;
using System.Collections.Generic;
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
	/// </summary>
	public class AirfieldRepository : BaseRepository, IAirfieldRepository
	{
		public AirfieldRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<List<Airfield>> FilterList(Func<Airfield, bool> func)
		{
			var list = await ListAsync();
			List<Airfield> ret = new List<Airfield>();
			foreach (Airfield airfield in list)
			{
				if (func(airfield))
					ret.Add(airfield);
			}
			return ret;
		}

		public async Task<List<Airfield>> FilterListShallow(Func<Airfield, bool> func)
		{
			var list = await ListShallowAsync();
			List<Airfield> ret = new List<Airfield>();
			foreach (Airfield airfield in list)
			{
				if (func(airfield))
					ret.Add(airfield);
			}
			return ret;
		}

		public async Task<Airfield> FindAround(IGlobalPoint globalPoint)
		{
			return await _context.Airfields
				.Include(ent => ent.StartFrom).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.EndedAt).ThenInclude(ent => ent.PlaceOfTakeoff)
				.SingleAsync(ent => GlobalPoint.Distance(ent, globalPoint) <= Constants.AIRFIELD_DESIGNATED_AREA_RADIUS);
		}

		public async Task<Airfield> GetAsync(Guid id)
		{
			return await _context.Airfields
				.Include(ent => ent.StartFrom).ThenInclude(ent => ent.PlaceOfLanding)
				.Include(ent => ent.EndedAt).ThenInclude(ent => ent.PlaceOfTakeoff)
				.SingleAsync(ent => ent.ID.Equals(id));
		}

		public async Task<Airfield> GetShallowAsync(Guid id)
		{
			return await _context.Airfields
				.SingleAsync(ent => ent.ID == id);
		}

		public Task<List<Airfield>> ListAsync()
		{
			return _context.Airfields
				.Include(ent => ent.StartFrom)
				.Include(ent => ent.EndedAt).ToListAsync();
		}

		public Task<List<Airfield>> ListShallowAsync()
		{
			return _context.Airfields
				.ToListAsync();
		}

		public async Task<Airfield> UnvalidatedInsertAsync(Airfield airfield)
		{
			var ret = _context.Airfields.Add(airfield);
			await _context.SaveChangesAsync();
			return ret.Entity;
		}
	}
}
