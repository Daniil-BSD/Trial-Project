using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trial_Task_Model.Models;
using static Trial_Task_BLL.RoleManagment.Role;

namespace Trial_Task_BLL.RoleManagment
{
	/// <summary>
	/// Defines the <see cref="Policies" />
	/// </summary>
	public static class Policies
	{
		public const string ADMINS = "ADMINISTRATION";

		public const string MEMBERS = "MEMBERS";

		public const string RESTRICTED = "SUPER ADMIN RESTRICTED";

		public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
		{
			var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
			var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
			foreach (var roleName in Role.ToStrings())
			{
				var roleExist = await RoleManager.RoleExistsAsync(roleName);
				if (!roleExist)
				{
					var roleResult = await RoleManager.CreateAsync(new IdentityRole<Guid>(roleName));
				}
			}

			var poweruser = new User
			{
				UserName = configuration.GetSection("SuperAdminSettings")["UserName"],
				Email = configuration.GetSection("SuperAdminSettings")["UserEmail"]
			};
			string userPassword = configuration.GetSection("SuperAdminSettings")["UserPassword"];
			var user = await UserManager.FindByEmailAsync(configuration.GetSection("SuperAdminSettings")["UserEmail"]);
			if (user == null)
			{
				var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
				if (createPowerUser.Succeeded)
				{
					await UserManager.AddToRoleAsync(poweruser, RoleEnum.SuperAddmin.GetName());
				}
			}
		}

		// additional policies are to be added here
		public static AuthorizationPolicy GetAuthorizationPolicy(string policyName)
		{
			AuthorizationPolicyBuilder builder = new AuthorizationPolicyBuilder();
			switch (policyName)
			{
				case MEMBERS:
					return builder.RequireRole(RoleEnum.Member.GetName()).Build();
				case ADMINS:
					return builder.RequireRole(RoleEnum.Admin.GetName()).Build();
				case RESTRICTED:
					return builder.RequireRole(RoleEnum.SuperAddmin.GetName()).Build();
			}
			throw new ArgumentException("Must recive one of the constants of this class as a policyName");
		}
	}
}
