using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task.APIInterface
{
	public interface IAPIFlightsController
	{
		Task<SpecificObjectResult<List<FlightBasicDTO>>> GetAllReducedAsync();
		Task<SpecificObjectResult<FlightDTO>> GetAsync(string id);
		Task<SpecificObjectResult<FlightBasicDTO>> GetBaisicAsync(string id);
		Task<SpecificObjectResult<FlightBasicDTO>> UpdateStatus([FromBody] FlightStatusUpdateDTO flightStatusUpdateDTO);
	}
}
