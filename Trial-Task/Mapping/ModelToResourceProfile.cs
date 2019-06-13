using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Trial_Task.Domain.Models;
using Trial_Task.Resoursces;

namespace Trial_Task.Mapping
{
	public class ModelToResourceProfile : Profile
	{
		public ModelToResourceProfile()
		{
			CreateMap<Airfield, AirfieldResource>();
			CreateMap<Airfield, AirfieldBaisicResource>();
			CreateMap<Airfield, AirfieldShallowResource>();
		}
	}
}
