using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace Trial_Task.Controllers
{
	/*
	This is my Controller superclass that includes a mapper into all other controllers.
	*/
	public abstract class BaseController : Controller
	{

		protected readonly IMapper _mapper;

		public BaseController(IMapper mapper)
		{
			_mapper = mapper;
		}
	}
}
