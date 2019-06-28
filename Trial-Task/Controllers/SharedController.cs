using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.APIInterface;
using Trial_Task_BLL.RoleManagment;
using Trial_Task_BLL.DTOs;

namespace Trial_Task_WEB.Controllers
{
	[Route("/[controller]")]
	public class SharedController : Controller
    {
		private readonly IAuthorizationService authorizationService;
		private readonly IAPIUsersController usersController;
		public SharedController(IAuthorizationService authorization, IAPIUsersController _usersController) {
			authorizationService = authorization;
			usersController = _usersController;
		}

		[HttpGet("header")]
        public async Task<IActionResult> Header()
		{
			if ((await authorizationService.AuthorizeAsync(User, Policies.ADMINS)).Succeeded)
			{
				return Redirect("/Shared/header-admin");
			} else if ((await authorizationService.AuthorizeAsync(User, Policies.MEMBERS)).Succeeded) {

				return Redirect("/Shared/header-user");
			}
			return Redirect("/Shared/header-guest");
		}
		//[Authorize(Policies.ADMINS)]
		[HttpGet("header-admin")]
		public async Task<IActionResult> HeaderAdmin()
		{
			var user = (UserBasicDTO)(await usersController.GetCurrentUser()).Object;
			return View(model: user);
		}

		//[Authorize(Policies.MEMBERS)]
		[HttpGet("header-user")]
		public async Task<IActionResult> HeaderUser()
		{
			var user = (UserBasicDTO)(await usersController.GetCurrentUser()).Object;
			return View(model: user);
		}

		[HttpGet("header-guest")]
		public IActionResult HeaderGuest()
		{
			return View();
		}
	}
}