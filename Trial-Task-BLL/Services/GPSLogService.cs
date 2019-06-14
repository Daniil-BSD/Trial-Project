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
	public class GPSLogService : BaseService, IGPSLogService
	{

		private readonly IGPSLogRepository _gpsLogRepository;

		public GPSLogService(IGPSLogRepository gpsLogRepository, IMapper mapper) : base(mapper)
		{
			_gpsLogRepository = gpsLogRepository;
		}

		public async Task<GPSLogDTO> GetAsync(Guid id)
		{
			var log = await _gpsLogRepository.GetAsync(id);
			return _mapper.Map<GPSLog, GPSLogDTO>(log);
		}

		public async Task<GPSLogStandaloneDTO> GetFullAsync(Guid id)
		{
			var log = await _gpsLogRepository.GetFullAsync(id);
			return _mapper.Map<GPSLog, GPSLogStandaloneDTO>(log);
		}

		public async Task<IEnumerable<GPSLogDTO>> ListAsync()
		{
			var logs = await _gpsLogRepository.ListAsync();
			return _mapper.Map<IEnumerable<GPSLog>, IEnumerable<GPSLogDTO>>(logs);
		}

		public async Task<IEnumerable<GPSLogBasicDTO>> ListReducedAsync()
		{
			var logs = await _gpsLogRepository.ListReducedAsync();
			return _mapper.Map<IEnumerable<GPSLog>, IEnumerable<GPSLogBasicDTO>>(logs);
		}

		public async Task<IEnumerable<GPSLogStandaloneListDTO>> ListStandaloneAsync()
		{
			var logs = await _gpsLogRepository.ListStandaloneAsync();
			return _mapper.Map<IEnumerable<GPSLog>, IEnumerable<GPSLogStandaloneListDTO>>(logs);
		}
	}
}
