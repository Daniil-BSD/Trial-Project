﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	public interface IAirfieldRepository
	{
		Task<IEnumerable<Airfield>> ListShallowAsync();
		Task<IEnumerable<Airfield>> ListAsync();
		Task<Airfield> GetAsync(Guid id);
		Task<Airfield> GetShallowAsync(Guid id);
	}
}