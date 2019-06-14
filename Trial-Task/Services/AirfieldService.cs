using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Repositories;
using Trial_Task.Domain.Services;

namespace Trial_Task.Services
{
	public class AirfieldService : IAirfieldService
	{

		private readonly IAirfieldRepository _airfieldRepository;

		public AirfieldService(IAirfieldRepository airfieldRepository)
		{
			_airfieldRepository = airfieldRepository;
		}

		public async Task<Airfield> GetAsync(Guid id)
		{
			return await _airfieldRepository.GetAsync(id);
		}

		public async Task<Airfield> GetShallowAsync(Guid id)
		{
			return await _airfieldRepository.GetShallowAsync(id);
		}

		public async Task<IEnumerable<Airfield>> ListAsync()
		{
			return await _airfieldRepository.ListAsync();
		}

		public async Task<IEnumerable<Airfield>> ListShallowAsync()
		{
			return await _airfieldRepository.ListShallowAsync();
		}
	}
}
