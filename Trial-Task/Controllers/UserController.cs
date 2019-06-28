using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trial_Task.APIInterface;
using Trial_Task_BLL.DTOs;

namespace Trial_Task.Controllers
{
	/// <summary>
	/// Defines the <see cref="UserController" />
	/// </summary>
	[Route("/[controller]")]
	public class UserController : Controller
	{
		private readonly IAPIUsersController usersController;

		public UserController(IAPIUsersController _usersController)
		{
			usersController = _usersController;
		}

		[HttpGet("login/{returnUrl?}")]
		public IActionResult Login(string errors = null, string returnUrl = null)
		{
			if (errors == null)
				return View(model: new string[0]);
			return View(model: errors.Split('|'));
		}

		[HttpPost("login/{returnUrl?}")]
		public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
		{
			if (userName != null && password != null)
			{
				UserLoginDTO userLoginDTO = new UserLoginDTO { UserName = userName, Password = password };
				var result = await usersController.SignIn(userLoginDTO);
				if (result.Valid)
				{
					if (returnUrl != null)
						return Redirect(returnUrl);
					return Redirect("/Flight/myFlights");
				}
				return Login((string)result.Value, returnUrl);
			}
			return Login();
		}

		[HttpPost("logout")]
		public async Task<IActionResult> LogOut()
		{
			usersController.SignOut();
			return Redirect("/User/login");
		}

		[HttpGet("register")]
		public IActionResult Register(string errors)
		{
			if (errors == null)
				return View(model: new string[0]);
			return View(model: errors.Split('|'));
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(string userName, string email, string password)
		{
			if (userName != null && password != null)
			{
				UserRegistrationDTO userRegistrationDTO = new UserRegistrationDTO { UserName = userName, Password = password, Email = email };
				var result = await usersController.Register(userRegistrationDTO);
				if (result.Valid)
					return Redirect("/Flight/myFlights");
				return Register((string)result.Value);
			}
			return Register(null);
		}
	}
}
