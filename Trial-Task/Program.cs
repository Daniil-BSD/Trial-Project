using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
			CreateWebHostBuilder(args).Build().Run();
		}
	}
}
