using AutoMapper;
using Trial_Task_BLL.DTOs;
using Trial_Task_Model.Models;

namespace Trial_Task_BLL.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//Model => DTOs

			CreateMap<Airfield, AirfieldDTO>();
			CreateMap<Airfield, AirfieldBasicDTO>();
			CreateMap<Airfield, AirfieldShallowDTO>();

			CreateMap<Flight, FlightDTO>();
			CreateMap<Flight, FlightShallowDTO>();
			CreateMap<Flight, FlightShallowPilotOriginatedDTO>();
			CreateMap<Flight, FlightBasicPilotOriginatedDTO>();
			CreateMap<Flight, FlightBasicDTO>();
			CreateMap<Flight, FlightLogOriginatedDTO>();

			CreateMap<GPSLog, GPSLogDTO>();
			CreateMap<GPSLog, GPSLogShallowDTO>();
			CreateMap<GPSLog, GPSLogBasicDTO>();
			CreateMap<GPSLog, GPSLogStandaloneDTO>();
			CreateMap<GPSLog, GPSLogStandaloneListDTO>();

			CreateMap<GPSLogEntry, GPSLogEntryDetailedDTO>();
			CreateMap<GPSLogEntry, GPSLogEntryDTO>();

			CreateMap<User, UserDTO>();
			CreateMap<User, UserShallowDTO>();
			CreateMap<User, UserBasicDTO>();

			//DTOs => Model
			CreateMap<AirfieldSaveDTO, Airfield>();
			CreateMap<UserRegistrationDTO, User>();

		}
	}
}
