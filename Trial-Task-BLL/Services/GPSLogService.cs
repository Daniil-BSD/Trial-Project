using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.Responses;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Services
{
	/// <summary>
	/// Defines the <see cref="GPSLogService" />
	/// </summary>
	public class GPSLogService : BaseService, IGPSLogService
	{
		private readonly IGPSLogRepository _gpsLogRepository;

		public GPSLogService(IGPSLogRepository gpsLogRepository, IMapper mapper, SignInManager<User> signInManager) : base(mapper, signInManager)
		{
			_gpsLogRepository = gpsLogRepository;
		}

		public async Task<Response<GPSLogDTO>> GetAsync(Guid id)
		{
			var task = _gpsLogRepository.GetAsync(id);
			return await Response<GPSLogDTO>.CatchInvalidOperationExceptionAndMap(task, _mapper);
		}

		public async Task<Response<GPSLogStandaloneDTO>> GetFullAsync(Guid id)
		{
			var task = _gpsLogRepository.GetFullAsync(id);
			return await Response<GPSLogStandaloneDTO>.CatchInvalidOperationExceptionAndMap(task, _mapper);
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
