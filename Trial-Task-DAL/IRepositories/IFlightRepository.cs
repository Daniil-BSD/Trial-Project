﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	public interface IFlightRepository
	{
		Task<IEnumerable<Flight>> ListAsync();
		Task<Flight> GetAsync(Guid id);
		Task<IEnumerable<Flight>> ListReducedAsync();
	}
}