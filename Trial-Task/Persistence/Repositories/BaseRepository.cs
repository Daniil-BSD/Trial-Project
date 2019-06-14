using Trial_Task.Persistence.Contexts;

namespace Trial_Task.Persistence.Repositories
{
	public abstract class BaseRepository
	{
		protected readonly AppDbContext _context;

		public BaseRepository(AppDbContext context)
		{
			_context = context;
		}
	}
}
