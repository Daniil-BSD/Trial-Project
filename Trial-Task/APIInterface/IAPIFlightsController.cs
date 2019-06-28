using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task.APIInterface
{
	/// <summary>
	/// Defines the <see cref="IAPIFlightsController" />
	/// </summary>
	public interface IAPIFlightsController
	{
		Task<SpecificObjectResult<List<FlightBasicDTO>>> GetAllReducedAsync();

		Task<SpecificObjectResult<FlightDTO>> GetAsync(string id);

		Task<SpecificObjectResult<FlightBasicDTO>> GetBaisicAsync(string id);

		Task<SpecificObjectResult<FlightBasicDTO>> UpdateStatus([FromBody] FlightStatusUpdateDTO flightStatusUpdateDTO);

		Task<SpecificObjectResult<FlightDTO>> UploadIGCFile(IFormFile file);
	}
}
