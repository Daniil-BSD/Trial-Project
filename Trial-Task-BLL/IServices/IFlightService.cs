﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_BLL.DTOs;

namespace Trial_Task_BLL.IServices
{
	public interface IFlightService
	{
		Task<IEnumerable<FlightShallowDTO>> ListAsync();
		Task<IEnumerable<FlightBasicDTO>> ListReducedAsync();
		Task<FlightDTO> GetAsync(Guid id);

	}
}