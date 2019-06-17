using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	public interface IFlightRepository
	{
		Task<List<Flight>> ListAsync();
		Task<List<Flight>> ListReducedAsync();
		Task<Flight> GetAsync(Guid id);
	}
}
