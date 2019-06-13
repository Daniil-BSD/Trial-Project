﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;

namespace Trial_Task.Domain.Services
{
	public interface IFlightService
	{
		Task<IEnumerable<Flight>> ListAsync();
		Task<IEnumerable<Flight>> ListReducedAsync();
		Task<Flight> GetAsync(Guid id);

	}
}
