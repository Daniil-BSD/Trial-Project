using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.Responses;

namespace Trial_Task_BLL.IServices
{
	/// <summary>
	/// Defines the <see cref="IFlightService" />
	/// </summary>
	public interface IFlightService
	{
		Task<Response<FlightDTO>> GetAsync(Guid id);

		Task<IEnumerable<FlightShallowDTO>> ListAsync();

		Task<IEnumerable<FlightBasicDTO>> ListReducedAsync();

		Task<Response<FlightDTO>> ParseIGCFile(string path);

		Task<Response<FlightBasicDTO>> UpdaateStatus(FlightStatusUpdateDTO flightStatusUpdateDTO);
	}
}
