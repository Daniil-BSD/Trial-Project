using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;

namespace Trial_Task_BLL.IServices
{
	public interface IAirfieldService
	{
		Task<IEnumerable<AirfieldShallowDTO>> ListShallowAsync();
		Task<IEnumerable<AirfieldDTO>> ListAsync();
		Task<AirfieldDTO> GetAsync(Guid id);
		Task<AirfieldShallowDTO> GetShallowAsync(Guid id);
	}
}
