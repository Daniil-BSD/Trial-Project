using System;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Swashbuckle.AspNetCore.Swagger;
using Trial_Task.APIInterface;
using Trial_Task_BLL.IServices;
using Trial_Task_BLL.Mapping;
using Trial_Task_BLL.RoleManagment;
using Trial_Task_BLL.Services;
using Trial_Task_DAL.Contexts;
using Trial_Task_DAL.IRepositories;
using Trial_Task_DAL.Repositories;
using Trial_Task_Model.Models;
using Trial_Task_WEB.ControllersAPI;

namespace Trial_Task
{
	/// <summary>
	/// Defines the <see cref="Startup" />
	/// </summary>
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				//app.UseDeveloperExceptionPage();

			} else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				c.RoutePrefix = string.Empty;
			});
			app.UseAuthentication();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options =>
			   options.UseSqlServer(
				   Configuration.GetConnectionString("DefaultConnection"),
				   b => b.MigrationsAssembly("Trial-Task-WEB")));

			services.AddIdentity<User, IdentityRole<Guid>>().AddEntityFrameworkStores<AppDbContext>();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
			});

			services.AddScoped<IAirfieldRepository, AirfieldRepository>();
			services.AddScoped<IAirfieldService, AirfieldService>();

			services.AddScoped<IFlightRepository, FlightRepository>();
			services.AddScoped<IFlightService, FlightService>();

			services.AddScoped<IGPSLogEntryRepository, GPSLogEntryRepository>();
			services.AddScoped<IGPSLogEntryService, GPSLogEntryService>();

			services.AddScoped<IGPSLogRepository, GPSLogRepository>();
			services.AddScoped<IGPSLogService, GPSLogService>();

			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserService, UserService>();

			services.AddScoped<IAPIFlightsController, APIFlightsController>();

			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});
			IMapper mapper = mappingConfig.CreateMapper();

			services.AddSingleton(mapper);

			services.AddSingleton<IFileProvider>(
				new PhysicalFileProvider(
					Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddAuthorization(options =>
			{
				options.AddPolicy(Policies.MEMBERS, Policies.GetAuthorizationPolicy(Policies.MEMBERS));
				options.AddPolicy(Policies.ADMINS, Policies.GetAuthorizationPolicy(Policies.ADMINS));
				options.AddPolicy(Policies.RESTRICTED, Policies.GetAuthorizationPolicy(Policies.RESTRICTED));
			});
		}
	}
}
