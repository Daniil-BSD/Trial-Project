using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.Responses;

namespace Trial_Task_BLL.IServices
{
	public interface IAirfieldService
	{
		Task<IEnumerable<AirfieldDTO>> ListAsync();
		Task<IEnumerable<AirfieldShallowDTO>> ListShallowAsync();
		Task<AirfieldDTO> GetAsync(Guid id);
		Task<AirfieldShallowDTO> GetShallowAsync(Guid id);
		Task<AirfieldSaveResponse> SaveAsync(AirfieldSaveDTO airfieldSaveDTO);
	}
}
