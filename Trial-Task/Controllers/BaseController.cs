using Microsoft.AspNetCore.Mvc;


namespace Trial_Task_WEB.Controllers
{
	public abstract class BaseController : Controller
	{
		public const string INVALID_ID_MESSAGE_STRING = "Invalid id format";
		public const string INVALID_MODEL_MESSAGE_STRING = "Invalid object structure";
	}
}
