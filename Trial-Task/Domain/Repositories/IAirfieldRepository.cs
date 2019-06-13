using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Domain.Repositories
{
    public interface IAirfieldRepository
    {
        Task<IEnumerable<Airfield>> ListShallowAsync();
		Task<IEnumerable<Airfield>> ListAsync();
		Task<Airfield> GetAsync(Guid id);
		Task<Airfield> GetShallowAsync(Guid id);
	}
}
