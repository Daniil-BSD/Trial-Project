using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task_DAL.Contexts;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.Repositories
{
	/// <summary>
	/// Defines the <see cref="IGCFileRecordRepository" />
	/// Missing method summeries coould be found in <see cref="IIGCFileRecordRepository"/>
	/// </summary>
	public class IGCFileRecordRepository : IIGCFileRecordRepository
	{
		protected readonly AppDbContext _context;

		public IGCFileRecordRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task DeleteAsync(IGCFileRecord fileRecord, bool saveChanges = true)
		{
			_context.UnporcessedFiles.Remove(fileRecord);
			if (saveChanges) await _context.SaveChangesAsync();
		}

		public Task<List<IGCFileRecord>> GetListOfFiles()
		{
			return _context.UnporcessedFiles
				.ToListAsync();
		}

		public async Task<IGCFileRecord> InsertAsync(IGCFileRecord fileRecord)
		{
			var ret = _context.UnporcessedFiles.Add(fileRecord);
			await _context.SaveChangesAsync();
			return ret.Entity;
		}
	}
}
