﻿using Trial_Task_DAL.Contexts;

namespace Trial_Task_DAL.Repositories
{
	/// <summary>
	/// Defines the <see cref="BaseRepository" />
	/// </summary>
	public abstract class BaseRepository
	{
		protected readonly AppDbContext _context;

		public BaseRepository(AppDbContext context)
		{
			_context = context;
		}
	}
}
