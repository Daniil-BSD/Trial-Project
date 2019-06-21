using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Trial_Task
{
	/// <summary>
	/// Defines the <see cref="Program" />
	/// </summary>
	public class Program
	{
		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();

		public static void Main(string[] args)
		{
			var host = CreateWebHostBuilder(args).Build();
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var serviceProvider = services.GetRequiredService<IServiceProvider>();
				var configuration = services.GetRequiredService<IConfiguration>();
				Trial_Task_BLL.RoleManagment.Policies.CreateRoles(serviceProvider, configuration).Wait();
			}

			host.Run();
		}
	}
}
