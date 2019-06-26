using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Services
{
	/// <summary>
	/// Defines the <see cref="GPSLogEntryService" />
	/// </summary>
	public class GPSLogEntryService : BaseService, IGPSLogEntryService
	{
		private readonly IGPSLogEntryRepository _gpsLogEntryRepository;

		public GPSLogEntryService(IGPSLogEntryRepository gpsLogEntryRepository, IMapper mapper, SignInManager<User> signInManager) : base(mapper, signInManager)
		{
			_gpsLogEntryRepository = gpsLogEntryRepository;
		}

		public async Task<List<GPSLogEntryDTO>> ListAsync(Guid id)
		{
			var entries = await _gpsLogEntryRepository.ListAsync(id);
			return _mapper.Map<List<GPSLogEntry>, List<GPSLogEntryDTO>>(entries);
		}
	}
}
