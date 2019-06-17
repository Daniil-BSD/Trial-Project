﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	/// <summary>
	/// Defines the <see cref="IAirfieldRepository" />
	/// </summary>
	public interface IAirfieldRepository
	{
		Task<Airfield> GetAsync(Guid id);

		Task<Airfield> GetShallowAsync(Guid id);

		Task<Airfield> InsertAsync(Airfield airfield);

		Task<List<Airfield>> ListAsync();

		Task<List<Airfield>> ListShallowAsync();
	}
}
