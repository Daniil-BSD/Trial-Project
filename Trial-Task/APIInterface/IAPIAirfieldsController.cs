using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.DTOs;
using Trial_Task_WEB.ResultExtention;

namespace Trial_Task.APIInterface
{
	/// <summary>
	/// Defines the <see cref="IAPIAirfieldsController" />
	/// </summary>
	public interface IAPIAirfieldsController
	{
		Task<SpecificObjectResult<List<AirfieldShallowDTO>>> GetAllAsync();

		Task<SpecificObjectResult<List<AirfieldDTO>>> GetAllFullAsync();

		Task<SpecificObjectResult<AirfieldShallowDTO>> GetShallowAsync(string id);

		Task<SpecificObjectResultList<AirfieldShallowDTO>> PostListAsync([FromBody] IEnumerable<AirfieldSaveDTO> airfieldSaveDTOs);

		Task<SpecificObjectResult<AirfieldShallowDTO>> PostSingleAsync([FromBody] AirfieldSaveDTO airfieldSaveDTO);

		Task<SpecificObjectResultList<AirfieldShallowDTO>> UploadXLSXFile(IFormFile file);
	}
}
