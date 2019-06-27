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
	/// Class for managment of <see cref="Microsoft.AspNetCore.Authorization.AuthorizationPolicy" /> across the application.
	/// 
	/// Constants of this class contain policy names, so all services and controllers requiring them should use these coonstants.
	/// </summary>
	public static class Policies
	{
		public const string ADMINS = "ADMINISTRATION";

		public const string MEMBERS = "MEMBERS";

		public const string RESTRICTED = "SUPER ADMIN RESTRICTED";

		// additional policies are to be added here


		/// <summary>
		/// Creates missing Roles and registers the Superadmin, meant to run before the startup.
		/// </summary>
		/// <param name="serviceProvider">The serviceProvider<see cref="IServiceProvider"/></param>
		/// <param name="configuration">The configuration<see cref="IConfiguration"/></param>
		/// <returns>The <see cref="Task"/></returns>
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
					await UserManager.AddToRoleAsync(poweruser, RoleEnum.Member.GetName());
					await UserManager.AddToRoleAsync(poweruser, RoleEnum.Admin.GetName());
					await UserManager.AddToRoleAsync(poweruser, RoleEnum.SuperAdmin.GetName());
				}
			}
		}

		/// <summary>
		/// Meant to be used during the Authentication configuration to assign proper policies to the proper constants
		/// </summary>
		/// <param name="policyName">here the constant of this class is meant to be passed as a parameter</param>
		/// <returns>The <see cref="AuthorizationPolicy"/> meant for the provided constant.</returns>
		/// When adding a new policy, it should be defined here, and then referenced in the services.AddAuthorization is startup like so:
		/// "options.AddPolicy(Policies.NEWPOLICY, Policies.GetAuthorizationPolicy(Policies.NEWPOLICY));"
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
					return builder.RequireRole(RoleEnum.SuperAdmin.GetName()).Build();
			}
			throw new ArgumentException("Must recive one of the constants of this class as a policyName");
		}
	}
}
