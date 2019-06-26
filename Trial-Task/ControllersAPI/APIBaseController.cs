using Microsoft.AspNetCore.Mvc;

namespace Trial_Task_WEB.ControllersAPI
{
	/// <summary>
	/// Defines the <see cref="APIBaseController" />
	/// </summary>
	public abstract class APIBaseController : Controller
	{
		public const string INVALID_ID_MESSAGE_STRING = "Invalid id format";

		public const string INVALID_MODEL_MESSAGE_STRING = "Invalid object structure";
	}
}
