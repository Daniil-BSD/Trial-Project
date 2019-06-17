using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.IRepositories
{
	public interface IAirfieldRepository
	{
		Task<List<Airfield>> ListShallowAsync();
		Task<List<Airfield>> ListAsync();
		Task<Airfield> GetAsync(Guid id);
		Task<Airfield> GetShallowAsync(Guid id);
		Task<Airfield> InsertAsync(Airfield airfield);
	}
}
