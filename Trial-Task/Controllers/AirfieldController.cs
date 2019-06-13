using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.Domain.Models;
using Trial_Task.Domain.Services;

namespace Trial_Task.Controllers
{
    [Route("/api/[controller]")]
    public class AirfieldsController : Controller
    {

        private readonly IAirfieldService _airfieldService;

        public AirfieldsController(IAirfieldService airfieldService)
        {
            _airfieldService = airfieldService;
        }

        [HttpGet]
        public async Task<IEnumerable<Airfield>> GetAllAsync()
        {
            var categories = await _airfieldService.ListAsync();
            return categories;
        }
    }
}
