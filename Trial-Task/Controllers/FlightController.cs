using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.APIInterface;
using Trial_Task_BLL.DTOs;
using Trial_Task_BLL.RoleManagment;
using Trial_Task_Model.Enumerations;
using Trial_Task_WEB.ControllersAPI;
using Trial_Task_WEB.ResultExtention;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trial_Task.Controllers
{
	[Route("/[controller]")]
	public class FlightController : Controller
	{
		private readonly IAPIFlightsController flightsController;
		private readonly IAPIUsersController usersController;
		private readonly IAuthorizationService authorizationService;
		public FlightController(IAPIFlightsController aPIFlights, IAPIUsersController aPIUsers, IAuthorizationService authorization) {
			flightsController = aPIFlights;
			usersController = aPIUsers;
			authorizationService = authorization;
		}

		[HttpGet("DV{id}")]
		public async Task<IActionResult> DetailedView(string id)
		{
			if((await authorizationService.AuthorizeAsync(User, Policies.ADMINS)).Succeeded) {
				return Redirect("DAV" + id);
			}
			return Redirect("DUV" + id); 
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

		[Authorize(Policy = Policies.ADMINS)]
		[HttpPost("updateStatus")]
		public async Task<IActionResult> UpdateStatus(byte status, string target)
		{
			try
			{
				var v = await flightsController.UpdateStatus(new FlightStatusUpdateDTO {
					Status = (EFlightStatus)status,
					Target = new Guid(target)
				});
			}
			catch (FormatException)
			{
			}
			return Redirect("~/Flight/DAV" + target);
		}

		[Authorize(Policy = Policies.ADMINS)]
		[HttpGet("allFFlights/{filter}")]
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

		[HttpGet("allFFlights")]
		public async Task<IActionResult> FlightsTableAdmin() {
			var flightsAll = (await flightsController.GetAllReducedAsync()).Object;
			return View(model: flightsAll);
		}

		[HttpGet("myFlights")]
		public async Task<IActionResult> FlightsTableUser()
		{
			var user = (await usersController.GetCurrentFullUser()).Object;
			return View(model: user);
		}
	}
}
