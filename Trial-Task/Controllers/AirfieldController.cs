using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.APIInterface;
using Trial_Task_BLL.RoleManagment;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Trial_Task.Controllers
{
	/// <summary>
	/// Defines the <see cref="AirfieldController" />
	/// </summary>
	[Route("/[controller]")]
	public class AirfieldController : Controller
	{
		private readonly IAPIAirfieldsController airfieldsController;

		private readonly IAPIUsersController usersController;

		public AirfieldController(IAPIUsersController _usersController, IAPIAirfieldsController _airfieldsController)
		{
			usersController = _usersController;
			airfieldsController = _airfieldsController;
		}

		[HttpGet("table")]
		public async Task<IActionResult> AirfieldsTable()
		{
			var flightsAll = (await airfieldsController.GetAllFullAsync()).Object;
			return View(model: flightsAll);
		}

		[Authorize(Policy = Policies.MEMBERS)]
		[HttpGet("upload")]
		public async Task<IActionResult> UploadAirfields()
		{
			var user = (await usersController.GetCurrentFullUser()).Object;
			return View();
		}

		[Authorize(Policy = Policies.MEMBERS)]
		[HttpPost("upload")]
		public async Task<IActionResult> UploadAirfields(IFormFile file)
		{
			var result = await airfieldsController.UploadXLSXFile(file);
			if (result.NotNull)
			{
				return Redirect("table");
			}
			return View();
		}
	}
}
