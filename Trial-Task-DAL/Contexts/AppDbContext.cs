using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trial_Task_Model.Models;

namespace Trial_Task_DAL.Contexts
{
	public class AppDbContext : IdentityDbContext
	{
		public DbSet<Airfield> Airfields { get; set; }
		public DbSet<Flight> Flights { get; set; }
		public DbSet<GPSLog> GPSLogs { get; set; }
		public DbSet<GPSLogEntry> GPSLogEntries { get; set; }
		new public DbSet<User> Users { get; set; }


		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
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

			builder.Entity<User>().HasKey(u => u.Guid_ID);


			// testing material
			/*builder.Entity<Airfield>().HasData
			(
				new Airfield { ID = new Guid("11111111-0000-1111-1111-111111111111"), Name = "Airfield 1", Latitude = 45.0, Longitude = 44.0 },
				new Airfield { ID = new Guid("11111111-1111-1111-1111-111111111111"), Name = "Airfield 2", Latitude = 44.0, Longitude = 45.0 }
			);*/
		}
	}
}
