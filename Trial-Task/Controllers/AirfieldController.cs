using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Services;
using Trial_Task.Resoursces;

namespace Trial_Task.Controllers
{
    [Route("/api/[controller]")]
    public class AirfieldsController : BaseController
    {

        private readonly IAirfieldService _airfieldService;

		public AirfieldsController(IAirfieldService airfieldService, IMapper mapper): base(mapper)
		{
            _airfieldService = airfieldService;
		}
			
        [HttpGet]
        public async Task<IEnumerable<AirfieldShallowResource>> GetAllAsync()
        {
            var airfields = await _airfieldService.ListAsync();
			var resources = _mapper.Map<IEnumerable<Airfield>, IEnumerable<AirfieldShallowResource>>(airfields);
			return resources;
        }
    }
}
