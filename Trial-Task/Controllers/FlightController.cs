using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.APIInterface;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.RoleManagment;
using Trial_Task_Model.Enumerations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Trial_Task.Controllers
{
	/// <summary>
	/// Defines the <see cref="FlightController" />
	/// </summary>
	[Route("/[controller]")]
	public class FlightController : Controller
	{
		private readonly IAuthorizationService authorizationService;

		private readonly IAPIFlightsController flightsController;

		private readonly IAPIUsersController usersController;

		public FlightController(IAPIFlightsController aPIFlights, IAPIUsersController aPIUsers, IAuthorizationService authorization)
		{
			flightsController = aPIFlights;
			usersController = aPIUsers;
			authorizationService = authorization;
		}

		// GET: /<controller>/
		[HttpGet("DAV{id}")]
		[Authorize(Policies.ADMINS)]
		public async Task<IActionResult> DetailedAdminView(string id)
		{
			var flight = (await flightsController.GetAsync(id)).Object;
			return View(model: flight);
		}

		[HttpGet("DUV{id}")]
		public async Task<IActionResult> DetailedUserView(string id)
		{
			var flight = (await flightsController.GetAsync(id)).Object;
			return View(model: flight);
		}

		[HttpGet("DV{id}")]
		public async Task<IActionResult> DetailedView(string id)
		{
			if ((await authorizationService.AuthorizeAsync(User, Policies.ADMINS)).Succeeded)
			{
				return Redirect("DAV" + id);
			}
			return Redirect("DUV" + id);
		}

		[Authorize(Policy = Policies.ADMINS)]
		[HttpGet("allFlights")]
		public async Task<IActionResult> FlightsTableAdmin()
		{
			var flightsAll = (await flightsController.GetAllReducedAsync()).Object;
			return View(model: flightsAll);
		}

		[Authorize(Policy = Policies.ADMINS)]
		[HttpGet("allFlights/{filter}")]
		public async Task<IActionResult> FlightsTableAdmin(string filter)
		{
			EFlightStatus status = EFlightStatus.Pending;
			var flightsAll = (await flightsController.GetAllReducedAsync()).Object;
			try
			{
				status.SetTo(filter);
				List<FlightBasicDTO> flights = new List<FlightBasicDTO>();
				foreach (var flight in flightsAll)
				{
					if (flight.Status == status)
					{
						flights.Add(flight);
					}
				}
				return View(model: flights);
			}
			catch (ArgumentException)
			{
				return View(model: flightsAll);
			}
		}

		[Authorize(Policy = Policies.MEMBERS)]
		[HttpGet("myFlights")]
		public async Task<IActionResult> FlightsTableUser()
		{
			var user = (await usersController.GetCurrentUser()).Object;
			return View(model: user);
		}

		[Authorize(Policy = Policies.ADMINS)]
		[HttpPost("updateStatus")]
		public async Task<IActionResult> UpdateStatus(byte status, string target)
		{
			try
			{
				var v = await flightsController.UpdateStatus(new FlightStatusUpdateDTO
				{
					Status = (EFlightStatus)status,
					Target = new Guid(target)
				});
			}
			catch (FormatException)
			{
			}
			return Redirect("~/Flight/DAV" + target);
		}

		[Authorize(Policy = Policies.MEMBERS)]
		[HttpGet("upload")]
		public async Task<IActionResult> UploadFlight()
		{
			return View();
		}

		[Authorize(Policy = Policies.MEMBERS)]
		[HttpPost("upload")]
		public async Task<IActionResult> UploadFlight(IFormFile file)
		{
			var result = await flightsController.UploadIGCFile(file);
			if (result.NotNull)
			{
				return Redirect("~/Flight/DV" + result.Object.ID);
			}
			return View();
		}
	}
}
