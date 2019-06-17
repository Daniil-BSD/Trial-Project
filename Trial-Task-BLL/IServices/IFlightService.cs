using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;

namespace Trial_Task_BLL.IServices
{
	/// <summary>
	/// Defines the <see cref="IFlightService" />
	/// </summary>
	public interface IFlightService
	{
		Task<FlightDTO> GetAsync(Guid id);

		Task<IEnumerable<FlightShallowDTO>> ListAsync();

		Task<IEnumerable<FlightBasicDTO>> ListReducedAsync();
	}
}
