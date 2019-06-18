using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.Responses;

namespace Trial_Task_BLL.IServices
{
	/// <summary>
	/// Defines the <see cref="IAirfieldService" />
	/// </summary>
	public interface IAirfieldService
	{
		Task<AirfieldDTO> GetAsync(Guid id);

		Task<AirfieldShallowDTO> GetShallowAsync(Guid id);

		Task<IEnumerable<AirfieldDTO>> ListAsync();

		Task<IEnumerable<AirfieldShallowDTO>> ListShallowAsync();

		Task<Response<AirfieldShallowDTO>> SaveAsync(AirfieldSaveDTO airfieldSaveDTO);
	}
}
