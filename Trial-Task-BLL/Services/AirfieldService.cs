using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.Responses;
using Trial_Task_DAL.IRepositories;
using Trial_Task_Model;
using Trial_Task_Model.Interfaces;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Services
{
	/// <summary>
	/// Defines the <see cref="AirfieldService" />
	/// </summary>
	public class AirfieldService : BaseService, IAirfieldService
	{
		private readonly IAirfieldRepository _airfieldRepository;

		public AirfieldService(IAirfieldRepository airfieldRepository, IMapper mapper, SignInManager<User> signInManager) : base(mapper, signInManager)
		{
			_airfieldRepository = airfieldRepository;
		}

		public async Task<Response<AirfieldDTO>> GetAsync(Guid id)
		{
			var task = _airfieldRepository.GetAsync(id);
			return await Response<AirfieldDTO>.CatchInvalidOperationExceptionAndMap(task, _mapper);
		}

		public async Task<Response<AirfieldShallowDTO>> GetShallowAsync(Guid id)
		{
			var task = _airfieldRepository.GetShallowAsync(id);
			return await Response<AirfieldShallowDTO>.CatchInvalidOperationExceptionAndMap(task, _mapper);
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

		public async Task<Response<AirfieldShallowDTO>> SaveAsync(AirfieldSaveDTO airfieldSaveDTO)
		{
			try
			{
				Airfield airfieldIm = _mapper.Map<AirfieldSaveDTO, Airfield>(airfieldSaveDTO);
				if (await IsGlobalPointValidForNewAirfield(airfieldIm))
				{
					var airfieldOut = await _airfieldRepository.UnvalidatedInsertAsync(airfieldIm);
					return new Response<AirfieldShallowDTO>(_mapper.Map<Airfield, AirfieldShallowDTO>(airfieldOut));
				} else
				{
					return new Response<AirfieldShallowDTO>("Newly entered airfield is too close to an exsisting one");
				}
			}
			catch (Exception e)
			{
				return new Response<AirfieldShallowDTO>(e.Message);
			}
		}

		internal async Task<bool> IsGlobalPointValidForNewAirfield(Airfield airfield)
		{
			var temp = await _airfieldRepository.FilterListShallow(ent => GlobalPoint.Distance(ent, airfield) < Constants.AIRFIELD_DESIGNATED_AREA_RADIUS);
			return temp.Count == 0;
		}
	}
}
