using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Repositories;
using Trial_Task.Domain.Services;

namespace Trial_Task.Services
{
    public class AirfieldService : IAirfieldService
    {

        private readonly IAirfieldRepository  _airfieldRepository;

        public AirfieldService(IAirfieldRepository airfieldRepository)
        {
            _airfieldRepository = airfieldRepository;
        }

        public async Task<IEnumerable<Airfield>> ListAsync()
        {
            return await _airfieldRepository.ListAsync();
        }
    }
}
