using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trial_Task_Model.Enumerations;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.Contexts
{
	/// <summary>
	/// Defines the <see cref=" DbContext" /> for this app.
	/// </summary>
	public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
	{
		public DbSet<Airfield> Airfields { get; set; }

		public DbSet<Flight> Flights { get; set; }

		public DbSet<GPSLogEntry> GPSLogEntries { get; set; }

		public DbSet<GPSLog> GPSLogs { get; set; }

		public DbSet<IGCFileRecord> UnporcessedFiles { get; set; }

		new public DbSet<User> Users { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		/// <summary>
		/// DB definition
		/// </summary>
		/// <param name="builder">The builder<see cref="ModelBuilder"/></param>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Airfield>().ToTable("Airfields");
			builder.Entity<Airfield>().HasKey(a => a.ID);
			builder.Entity<Airfield>().Property(a => a.ID).ValueGeneratedOnAdd();
			builder.Entity<Airfield>().Property(a => a.Name).IsRequired().HasMaxLength(60);
			builder.Entity<Airfield>().Property(a => a.Latitude).IsRequired();
			builder.Entity<Airfield>().Property(a => a.Latitude).IsRequired();

			builder.Entity<Flight>().ToTable("Flights");
			builder.Entity<Flight>().HasKey(f => f.ID);
			builder.Entity<Flight>().Property(f => f.Date).IsRequired();
			builder.Entity<Flight>().Property(f => f.LogID).IsRequired();
			builder.Entity<Flight>().HasOne(f => f.Log).WithOne(l => l.Flight).HasForeignKey<Flight>(f => f.LogID);
			builder.Entity<Flight>().Property(f => f.UserID).IsRequired();
			builder.Entity<Flight>().HasOne(f => f.Pilot).WithMany(u => u.Flights).HasForeignKey(f => f.UserID).OnDelete(DeleteBehavior.ClientSetNull);

			builder.Entity<GPSLog>().HasKey(l => l.ID);
			builder.Entity<GPSLog>().Property(l => l.Duration).IsRequired();
			builder.Entity<GPSLog>().Property(l => l.TakeoffID);
			builder.Entity<GPSLog>().HasOne(l => l.PlaceOfTakeoff).WithMany(a => a.StartFrom).HasForeignKey(l => l.TakeoffID).OnDelete(DeleteBehavior.ClientSetNull);
			builder.Entity<GPSLog>().Property(l => l.LandingID);
			builder.Entity<GPSLog>().HasOne(l => l.PlaceOfLanding).WithMany(a => a.EndedAt).HasForeignKey(l => l.LandingID).OnDelete(DeleteBehavior.ClientSetNull);

			builder.Entity<GPSLogEntry>().HasKey(le => new { le.LogID, le.Time });
			builder.Entity<GPSLogEntry>().HasOne(le => le.Log).WithMany(l => l.Entries).HasForeignKey(le => le.LogID);
			builder.Entity<GPSLogEntry>().Property(le => le.Latitude).IsRequired();
			builder.Entity<GPSLogEntry>().Property(le => le.Longitude).IsRequired();
			builder.Entity<GPSLogEntry>().Property(le => le.Altitude).IsRequired();

			builder.Entity<User>().HasKey(u => u.Id);

			builder.Entity<IGCFileRecord>().HasKey(fr => new { fr.UserID, fr.FilePath });
			builder.Entity<IGCFileRecord>().HasOne(f => f.Pilot).WithMany().HasForeignKey(f => f.UserID).OnDelete(DeleteBehavior.ClientSetNull);
		}

		/// <summary>
		/// The PopulateTablesWithTestingData does whaat it says, a seed for all the tables with disrigard for Identity.
		/// </summary>
		/// <param name="builder">The builder<see cref="ModelBuilder"/></param>
		private void PopulateTablesWithTestingData(ModelBuilder builder)
		{
			// testing material
			builder.Entity<Airfield>().HasData
			(
				new Airfield { ID = new Guid("11111111-0000-1111-1111-111111111111"), Name = "Airfield 1", Latitude = 45.0, Longitude = 45.0 },
				new Airfield { ID = new Guid("11111111-1111-1111-1111-111111111111"), Name = "Airfield 2", Latitude = 44.0, Longitude = 44.0 }
			);

			builder.Entity<User>().HasData
			(
				new User
				{
					Id = new Guid("11111111-0000-1111-1111-111111111111"),
					LockoutEnd = new DateTimeOffset(),
					LockoutEnabled = false,
					TwoFactorEnabled = false,
					PhoneNumberConfirmed = true,
					EmailConfirmed = true,
					Email = "123@123.com",
					UserName = "User1",
					NormalizedUserName = "user 1",
					PhoneNumber = "123412345",
					ConcurrencyStamp = "1234123412341234",
					SecurityStamp = "1234123412341234",
					PasswordHash = "1234",
					AccessFailedCount = 0
				},
				new User
				{
					Id = new Guid("11111111-1111-1111-1111-111111111111"),
					LockoutEnd = new DateTimeOffset(),
					LockoutEnabled = false,
					TwoFactorEnabled = false,
					PhoneNumberConfirmed = true,
					EmailConfirmed = true,
					Email = "1234@123.com",
					UserName = "User2",
					NormalizedUserName = "user 2",
					PhoneNumber = "1234123454",
					ConcurrencyStamp = "12341234123412344",
					SecurityStamp = "12341234123412344",
					PasswordHash = "12344",
					AccessFailedCount = 0
				}
			);
			builder.Entity<GPSLog>().HasData
			(
				new GPSLog
				{
					ID = new Guid("11111111-0000-1111-1111-111111111111"),
					Duration = new TimeSpan(1, 1, 1),
					TakeoffID = new Guid("11111111-0000-1111-1111-111111111111"),
					LandingID = new Guid("11111111-0000-1111-1111-111111111111")

				},
				new GPSLog
				{
					ID = new Guid("11111111-1111-1111-1111-111111111111"),
					Duration = new TimeSpan(2, 2, 2),
					TakeoffID = new Guid("11111111-0000-1111-1111-111111111111"),
					LandingID = new Guid("11111111-1111-1111-1111-111111111111")

				},

				new GPSLog
				{
					ID = new Guid("11111111-0000-0000-1111-111111111111"),
					Duration = new TimeSpan(1, 2, 3),
					TakeoffID = new Guid("11111111-1111-1111-1111-111111111111"),
					LandingID = new Guid("11111111-0000-1111-1111-111111111111")
				}
			);
			builder.Entity<GPSLogEntry>().HasData(
				new GPSLogEntry
				{
					LogID = new Guid("11111111-0000-1111-1111-111111111111"),
					Latitude = 45,
					Longitude = 45,
					Time = new DateTime(DateTime.Now.Ticks + 1000)
				}, new GPSLogEntry
				{
					LogID = new Guid("11111111-0000-1111-1111-111111111111"),
					Latitude = 46,
					Longitude = 45,
					Time = new DateTime(DateTime.Now.Ticks + 2000)
				}, new GPSLogEntry
				{
					LogID = new Guid("11111111-0000-1111-1111-111111111111"),
					Latitude = 46,
					Longitude = 46,
					Time = new DateTime(DateTime.Now.Ticks + 3000)
				}, new GPSLogEntry
				{
					LogID = new Guid("11111111-0000-1111-1111-111111111111"),
					Latitude = 45,
					Longitude = 46,
					Time = new DateTime(DateTime.Now.Ticks + 4000)
				}, new GPSLogEntry
				{
					LogID = new Guid("11111111-0000-1111-1111-111111111111"),
					Latitude = 45,
					Longitude = 45,
					Time = new DateTime(DateTime.Now.Ticks + 5000)
				},
				//======================================================================================
				new GPSLogEntry
				{
					LogID = new Guid("11111111-1111-1111-1111-111111111111"),
					Latitude = 44,
					Longitude = 44,
					Time = new DateTime(DateTime.Now.Ticks + 1000)
				}, new GPSLogEntry
				{
					LogID = new Guid("11111111-1111-1111-1111-111111111111"),
					Latitude = 44.5,
					Longitude = 44.5,
					Time = new DateTime(DateTime.Now.Ticks + 2000)
				}, new GPSLogEntry
				{
					LogID = new Guid("11111111-1111-1111-1111-111111111111"),
					Latitude = 45,
					Longitude = 45,
					Time = new DateTime(DateTime.Now.Ticks + 3000)
				},
				//======================================================================================
				new GPSLogEntry
				{
					LogID = new Guid("11111111-0000-0000-1111-111111111111"),
					Latitude = 45,
					Longitude = 45,
					Time = new DateTime(DateTime.Now.Ticks + 1000)
				}, new GPSLogEntry
				{
					LogID = new Guid("11111111-0000-0000-1111-111111111111"),
					Latitude = 44.5,
					Longitude = 44.5,
					Time = new DateTime(DateTime.Now.Ticks + 2000)
				}, new GPSLogEntry
				{
					LogID = new Guid("11111111-0000-0000-1111-111111111111"),
					Latitude = 44,
					Longitude = 44,
					Time = new DateTime(DateTime.Now.Ticks + 3000)
				}
			);
			builder.Entity<Flight>().HasData(
				new Flight
				{
					ID = new Guid("11111111-1111-1111-1111-111111111111"),
					LogID = new Guid("11111111-1111-1111-1111-111111111111"),
					Status = EFlightStatus.Approved,
					UserID = new Guid("11111111-1111-1111-1111-111111111111")
				},
				new Flight
				{
					ID = new Guid("11111111-0000-1111-1111-111111111111"),
					LogID = new Guid("11111111-0000-1111-1111-111111111111"),
					Status = EFlightStatus.Rejected,
					UserID = new Guid("11111111-0000-1111-1111-111111111111")
				},
				new Flight
				{
					ID = new Guid("11111111-0000-0000-1111-111111111111"),
					LogID = new Guid("11111111-0000-0000-1111-111111111111"),
					Status = EFlightStatus.Pending,
					UserID = new Guid("11111111-0000-1111-1111-111111111111")
				}
			);
		}
	}
}
