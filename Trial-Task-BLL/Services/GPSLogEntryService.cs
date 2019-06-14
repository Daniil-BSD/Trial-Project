using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Services
{
	public class GPSLogEntryService : BaseService, IGPSLogEntryService
	{

		private readonly IGPSLogEntryRepository _gpsLogEntryRepository;

		public GPSLogEntryService(IGPSLogEntryRepository gpsLogEntryRepository, IMapper mapper) : base(mapper)
		{
			_gpsLogEntryRepository = gpsLogEntryRepository;
		}

		public async Task<IEnumerable<GPSLogEntryDTO>> ListAsync(Guid id)
		{
			var entries = await _gpsLogEntryRepository.ListAsync(id);
			return _mapper.Map<IEnumerable<GPSLogEntry>, IEnumerable<GPSLogEntryDTO>>(entries);
		}
	}
}
