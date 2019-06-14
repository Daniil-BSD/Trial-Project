using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Domain.Repositories
{
	public interface IFlightRepository
	{
		Task<IEnumerable<Flight>> ListAsync();
		Task<Flight> ListGet(Guid id);
		Task<IEnumerable<Flight>> ListReducedAsync();
	}
}
