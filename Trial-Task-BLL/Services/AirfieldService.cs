﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Services
{
	public class AirfieldService : BaseService, IAirfieldService
	{

		private readonly IAirfieldRepository _airfieldRepository;

		public AirfieldService(IAirfieldRepository airfieldRepository, IMapper mapper) : base(mapper)
		{
			_airfieldRepository = airfieldRepository;
		}

		public async Task<AirfieldDTO> GetAsync(Guid id)
		{
			var airfield = await _airfieldRepository.GetAsync(id);
			return _mapper.Map<Airfield, AirfieldDTO>(airfield);
		}

		public async Task<AirfieldShallowDTO> GetShallowAsync(Guid id)
		{
			var airfield = await _airfieldRepository.GetAsync(id);
			return _mapper.Map<Airfield, AirfieldShallowDTO>(airfield);
		}

		public async Task<IEnumerable<AirfieldDTO>> ListAsync()
		{
			var airfields = await _airfieldRepository.ListAsync();
			return _mapper.Map<IEnumerable<Airfield>, IEnumerable<AirfieldDTO>>(airfields);
		}

		public async Task<IEnumerable<AirfieldShallowDTO>> ListShallowAsync()
		{
			var airfields = await _airfieldRepository.ListShallowAsync();
			return _mapper.Map<IEnumerable<Airfield>, IEnumerable<AirfieldShallowDTO>>(airfields);
		}
	}
}
