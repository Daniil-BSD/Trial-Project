using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Repositories;
using Trial_Task.Persistence.Contexts;

namespace Trial_Task.Persistence.Repositories
{
    public class AirfieldRepository: BaseRepository, IAirfieldRepository
    {
        public AirfieldRepository(AppDbContext context) : base(context){}

        public async Task<IEnumerable<Airfield>> ListAsync()
        {
            return await _context.Airfields.ToListAsync();
        }
    }
}
