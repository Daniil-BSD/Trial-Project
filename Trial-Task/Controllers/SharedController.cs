using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trial_Task_BLL.RoleManagment;

namespace Trial_Task_WEB.Controllers
{
	[Route("/[controller]")]
	public class SharedController : Controller
    {
		private readonly IAuthorizationService authorizationService;
		public SharedController(IAuthorizationService authorization) {
			authorizationService = authorization;
		}

		[HttpGet("header")]
        public async Task<IActionResult> Header()
		{
			if ((await authorizationService.AuthorizeAsync(User, Policies.ADMINS)).Succeeded)
			{
				return Redirect("header-admin");
			}
			return Redirect("header-user");
		}
		[HttpGet("header-admin")]
		public IActionResult HeaderAdmin()
		{
			return View();
		}

		[HttpGet("header-user")]
		public IActionResult HeaderUser()
		{
			return View();
		} 
	}
}