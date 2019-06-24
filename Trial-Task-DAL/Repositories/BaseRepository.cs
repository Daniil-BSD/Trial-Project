using System.Linq;
using System.Runtime.CompilerServices;
using Trial_Task_DAL.Contexts;

namespace Trial_Task_DAL.Repositories
{
	/// <summary>
	/// Defines the <see cref="BaseRepository" />
	/// </summary>
	public abstract class BaseRepository<T> where T : class
	{
		protected readonly AppDbContext _context;

		public BaseRepository(AppDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// A single point for managing full includes (meaning loading all the rows required by the most extensive DTO)
		/// (marked with [MethodImpl(MethodImplOptions.AggressiveInlining)])
		/// </summary>
		/// <returns>The <see cref="IQueryable{GPSLog}"/> that could b expanded upon</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected abstract IQueryable<T> GetFullIncludes();


		/// <summary>
		/// A single point for managing default includes (meaning loading all the rows required by the standart DTOs)
		/// (marked with [MethodImpl(MethodImplOptions.AggressiveInlining)])
		/// </summary>
		/// <returns>The <see cref="IQueryable{GPSLog}"/> that could b expanded upon</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected abstract IQueryable<T> GetStandartIncludes();

		/// <summary>
		/// A single point for managing minimal includes, in case some additiona includes or filters have to be added in every minimal request.
		/// (marked with [MethodImpl(MethodImplOptions.AggressiveInlining)])
		/// </summary>
		/// <returns>The <see cref="IQueryable{GPSLog}"/> that could b expanded upon</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected abstract IQueryable<T> GetNoIncludes();
	}
}
