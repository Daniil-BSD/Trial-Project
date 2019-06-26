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
		public FlightController(IAPIFlightsController api) {
			flightsController = api;
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
	}
}
