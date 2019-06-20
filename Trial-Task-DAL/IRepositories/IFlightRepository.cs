using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	/// <summary>
	/// Defines the <see cref="IFlightRepository" />
	/// </summary>
	public interface IFlightRepository
	{
		Task<Flight> GetAsync(Guid id);

		Task<Flight> InsertNewFlight(Flight flightIn);

		Task<List<Flight>> ListAsync();

		Task<List<Flight>> ListReducedAsync();
	}
}
