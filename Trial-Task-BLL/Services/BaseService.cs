using AutoMapper;

namespace Trial_Task_BLL.Services
{
	/// <summary>
	/// Defines the <see cref="BaseService" />
	/// Essentially used to ensure all Services have a mapper.
	/// </summary>
	public class BaseService
	{
		protected readonly IMapper _mapper;

		public BaseService(IMapper mapper)
		{
			_mapper = mapper;
		}
	}
}
