using AutoMapper;

namespace Trial_Task_BLL.Services
{
	public class BaseService
	{
		protected readonly IMapper _mapper;

		public BaseService(IMapper mapper)
		{
			_mapper = mapper;
		}
	}
}
