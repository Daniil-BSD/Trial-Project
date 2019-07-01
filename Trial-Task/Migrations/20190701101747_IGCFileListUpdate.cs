using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trial_Task.Migrations
{
	/// <summary>
	/// Defines the <see cref="IGCFileListUpdate" />
	/// </summary>
	public partial class IGCFileListUpdate : Migration
	{
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "UnporcessedFiles");

			migrationBuilder.InsertData(
				table: "Airfields",
				columns: new[] { "ID", "Latitude", "Longitude", "Name" },
				values: new object[,]
				{
					{ new Guid("11111111-0000-1111-1111-111111111111"), 45.0, 45.0, "Airfield 1" },
					{ new Guid("11111111-1111-1111-1111-111111111111"), 44.0, 44.0, "Airfield 2" }
				});

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[,]
				{
					{ new Guid("11111111-0000-1111-1111-111111111111"), 0, "1234123412341234", "123@123.com", true, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "user 1", "1234", "123412345", true, "1234123412341234", false, "User1" },
					{ new Guid("11111111-1111-1111-1111-111111111111"), 0, "12341234123412344", "1234@123.com", true, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "user 2", "12344", "1234123454", true, "12341234123412344", false, "User2" }
				});

			migrationBuilder.InsertData(
				table: "GPSLogs",
				columns: new[] { "ID", "Duration", "LandingID", "TakeoffID" },
				values: new object[] { new Guid("11111111-0000-1111-1111-111111111111"), new TimeSpan(0, 1, 1, 1, 0), new Guid("11111111-0000-1111-1111-111111111111"), new Guid("11111111-0000-1111-1111-111111111111") });

			migrationBuilder.InsertData(
				table: "GPSLogs",
				columns: new[] { "ID", "Duration", "LandingID", "TakeoffID" },
				values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new TimeSpan(0, 2, 2, 2, 0), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-0000-1111-1111-111111111111") });

			migrationBuilder.InsertData(
				table: "GPSLogs",
				columns: new[] { "ID", "Duration", "LandingID", "TakeoffID" },
				values: new object[] { new Guid("11111111-0000-0000-1111-111111111111"), new TimeSpan(0, 1, 2, 3, 0), new Guid("11111111-0000-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") });

			migrationBuilder.InsertData(
				table: "Flights",
				columns: new[] { "ID", "Date", "LogID", "Status", "UserID" },
				values: new object[,]
				{
					{ new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-0000-1111-1111-111111111111"), (byte)2, new Guid("11111111-0000-1111-1111-111111111111") },
					{ new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111"), (byte)1, new Guid("11111111-1111-1111-1111-111111111111") },
					{ new Guid("11111111-0000-0000-1111-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-0000-0000-1111-111111111111"), (byte)0, new Guid("11111111-0000-1111-1111-111111111111") }
				});

			migrationBuilder.InsertData(
				table: "GPSLogEntries",
				columns: new[] { "LogID", "Time", "Latitude", "Longitude" },
				values: new object[,]
				{
					{ new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 308, DateTimeKind.Unspecified).AddTicks(6225), 45.0, 45.0 },
					{ new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(8406), 46.0, 45.0 },
					{ new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(9438), 46.0, 46.0 },
					{ new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 311, DateTimeKind.Unspecified).AddTicks(448), 45.0, 46.0 },
					{ new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 311, DateTimeKind.Unspecified).AddTicks(1456), 45.0, 45.0 },
					{ new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(7468), 44.0, 44.0 },
					{ new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(8476), 44.5, 44.5 },
					{ new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(9484), 45.0, 45.0 },
					{ new Guid("11111111-0000-0000-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(7494), 45.0, 45.0 },
					{ new Guid("11111111-0000-0000-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(8502), 44.5, 44.5 },
					{ new Guid("11111111-0000-0000-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(9511), 44.0, 44.0 }
				});
		}

		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Flights",
				keyColumn: "ID",
				keyValue: new Guid("11111111-0000-0000-1111-111111111111"));

			migrationBuilder.DeleteData(
				table: "Flights",
				keyColumn: "ID",
				keyValue: new Guid("11111111-0000-1111-1111-111111111111"));

			migrationBuilder.DeleteData(
				table: "Flights",
				keyColumn: "ID",
				keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

			migrationBuilder.DeleteData(
				table: "GPSLogEntries",
				keyColumns: new[] { "LogID", "Time" },
				keyValues: new object[] { new Guid("11111111-0000-0000-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(7494) });

			migrationBuilder.DeleteData(
				table: "GPSLogEntries",
				keyColumns: new[] { "LogID", "Time" },
				keyValues: new object[] { new Guid("11111111-0000-0000-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(8502) });

			migrationBuilder.DeleteData(
				table: "GPSLogEntries",
				keyColumns: new[] { "LogID", "Time" },
				keyValues: new object[] { new Guid("11111111-0000-0000-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(9511) });

			migrationBuilder.DeleteData(
				table: "GPSLogEntries",
				keyColumns: new[] { "LogID", "Time" },
				keyValues: new object[] { new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 308, DateTimeKind.Unspecified).AddTicks(6225) });

			migrationBuilder.DeleteData(
				table: "GPSLogEntries",
				keyColumns: new[] { "LogID", "Time" },
				keyValues: new object[] { new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(8406) });

			migrationBuilder.DeleteData(
				table: "GPSLogEntries",
				keyColumns: new[] { "LogID", "Time" },
				keyValues: new object[] { new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(9438) });

			migrationBuilder.DeleteData(
				table: "GPSLogEntries",
				keyColumns: new[] { "LogID", "Time" },
				keyValues: new object[] { new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 311, DateTimeKind.Unspecified).AddTicks(448) });

			migrationBuilder.DeleteData(
				table: "GPSLogEntries",
				keyColumns: new[] { "LogID", "Time" },
				keyValues: new object[] { new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 311, DateTimeKind.Unspecified).AddTicks(1456) });

			migrationBuilder.DeleteData(
				table: "GPSLogEntries",
				keyColumns: new[] { "LogID", "Time" },
				keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(7468) });

			migrationBuilder.DeleteData(
				table: "GPSLogEntries",
				keyColumns: new[] { "LogID", "Time" },
				keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(8476) });

			migrationBuilder.DeleteData(
				table: "GPSLogEntries",
				keyColumns: new[] { "LogID", "Time" },
				keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2019, 6, 28, 12, 54, 8, 310, DateTimeKind.Unspecified).AddTicks(9484) });

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("11111111-0000-1111-1111-111111111111"));

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

			migrationBuilder.DeleteData(
				table: "GPSLogs",
				keyColumn: "ID",
				keyValue: new Guid("11111111-0000-0000-1111-111111111111"));

			migrationBuilder.DeleteData(
				table: "GPSLogs",
				keyColumn: "ID",
				keyValue: new Guid("11111111-0000-1111-1111-111111111111"));

			migrationBuilder.DeleteData(
				table: "GPSLogs",
				keyColumn: "ID",
				keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

			migrationBuilder.DeleteData(
				table: "Airfields",
				keyColumn: "ID",
				keyValue: new Guid("11111111-0000-1111-1111-111111111111"));

			migrationBuilder.DeleteData(
				table: "Airfields",
				keyColumn: "ID",
				keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

			migrationBuilder.CreateTable(
				name: "UnporcessedFiles",
				columns: table => new
				{
					FilePath = table.Column<string>(nullable: false),
					UserID = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UnporcessedFiles", x => new { x.UserID, x.FilePath });
					table.ForeignKey(
						name: "FK_UnporcessedFiles_AspNetUsers_UserID",
						column: x => x.UserID,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});
		}
	}
}
