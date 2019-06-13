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
    public class GPSLogEntriesController : Controller
    {

        private readonly IGPSLogEntryService _gpsLogEntryService;

        public GPSLogEntriesController(IGPSLogEntryService gpsLogEntryService)
        {
			_gpsLogEntryService = gpsLogEntryService;
        }

        [HttpGet]
        public async Task<IEnumerable<GPSLogEntry>> GetAllAsync()
        {
            var entries = await _gpsLogEntryService.ListAsync();
            return entries;
        }
    }
}
