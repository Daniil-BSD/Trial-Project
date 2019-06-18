﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trial_Task.Migrations
{
	public partial class _114418062019 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Airfields",
				columns: table => new
				{
					ID = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(maxLength: 60, nullable: false),
					Latitude = table.Column<double>(nullable: false),
					Longitude = table.Column<double>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Airfields", x => x.ID);
				});

			migrationBuilder.CreateTable(
				name: "AspNetRoles",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(maxLength: 256, nullable: true),
					NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
					ConcurrencyStamp = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUsers",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					UserName = table.Column<string>(maxLength: 256, nullable: true),
					NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
					Email = table.Column<string>(maxLength: 256, nullable: true),
					NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
					EmailConfirmed = table.Column<bool>(nullable: false),
					PasswordHash = table.Column<string>(nullable: true),
					SecurityStamp = table.Column<string>(nullable: true),
					ConcurrencyStamp = table.Column<string>(nullable: true),
					PhoneNumber = table.Column<string>(nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(nullable: false),
					TwoFactorEnabled = table.Column<bool>(nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
					LockoutEnabled = table.Column<bool>(nullable: false),
					AccessFailedCount = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUsers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "GPSLogs",
				columns: table => new
				{
					ID = table.Column<Guid>(nullable: false),
					Duration = table.Column<TimeSpan>(nullable: false),
					TakeoffID = table.Column<Guid>(nullable: false),
					LandingID = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GPSLogs", x => x.ID);
					table.ForeignKey(
						name: "FK_GPSLogs_Airfields_LandingID",
						column: x => x.LandingID,
						principalTable: "Airfields",
						principalColumn: "ID",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GPSLogs_Airfields_TakeoffID",
						column: x => x.TakeoffID,
						principalTable: "Airfields",
						principalColumn: "ID",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "AspNetRoleClaims",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					RoleId = table.Column<Guid>(nullable: false),
					ClaimType = table.Column<string>(nullable: true),
					ClaimValue = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserClaims",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					UserId = table.Column<Guid>(nullable: false),
					ClaimType = table.Column<string>(nullable: true),
					ClaimValue = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetUserClaims_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserLogins",
				columns: table => new
				{
					LoginProvider = table.Column<string>(nullable: false),
					ProviderKey = table.Column<string>(nullable: false),
					ProviderDisplayName = table.Column<string>(nullable: true),
					UserId = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
					table.ForeignKey(
						name: "FK_AspNetUserLogins_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserRoles",
				columns: table => new
				{
					UserId = table.Column<Guid>(nullable: false),
					RoleId = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserTokens",
				columns: table => new
				{
					UserId = table.Column<Guid>(nullable: false),
					LoginProvider = table.Column<string>(nullable: false),
					Name = table.Column<string>(nullable: false),
					Value = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
					table.ForeignKey(
						name: "FK_AspNetUserTokens_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Flights",
				columns: table => new
				{
					ID = table.Column<Guid>(nullable: false),
					Date = table.Column<DateTime>(nullable: false),
					Status = table.Column<byte>(nullable: false),
					LogID = table.Column<Guid>(nullable: false),
					UserID = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Flights", x => x.ID);
					table.ForeignKey(
						name: "FK_Flights_GPSLogs_LogID",
						column: x => x.LogID,
						principalTable: "GPSLogs",
						principalColumn: "ID",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Flights_AspNetUsers_UserID",
						column: x => x.UserID,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GPSLogEntries",
				columns: table => new
				{
					LogID = table.Column<Guid>(nullable: false),
					Time = table.Column<DateTime>(nullable: false),
					Latitude = table.Column<double>(nullable: false),
					Longitude = table.Column<double>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GPSLogEntries", x => new { x.LogID, x.Time });
					table.ForeignKey(
						name: "FK_GPSLogEntries_GPSLogs_LogID",
						column: x => x.LogID,
						principalTable: "GPSLogs",
						principalColumn: "ID",
						onDelete: ReferentialAction.Cascade);
				});

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
					{ new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 18, 11, 44, 16, 412, DateTimeKind.Unspecified).AddTicks(5177), 45.0, 45.0 },
					{ new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 18, 11, 44, 16, 414, DateTimeKind.Unspecified).AddTicks(5738), 46.0, 45.0 },
					{ new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 18, 11, 44, 16, 414, DateTimeKind.Unspecified).AddTicks(6771), 46.0, 46.0 },
					{ new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 18, 11, 44, 16, 414, DateTimeKind.Unspecified).AddTicks(7783), 45.0, 46.0 },
					{ new Guid("11111111-0000-1111-1111-111111111111"), new DateTime(2019, 6, 18, 11, 44, 16, 414, DateTimeKind.Unspecified).AddTicks(8791), 45.0, 45.0 },
					{ new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2019, 6, 18, 11, 44, 16, 414, DateTimeKind.Unspecified).AddTicks(4801), 44.0, 44.0 },
					{ new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2019, 6, 18, 11, 44, 16, 414, DateTimeKind.Unspecified).AddTicks(5809), 44.5, 44.5 },
					{ new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2019, 6, 18, 11, 44, 16, 414, DateTimeKind.Unspecified).AddTicks(6817), 45.0, 45.0 },
					{ new Guid("11111111-0000-0000-1111-111111111111"), new DateTime(2019, 6, 18, 11, 44, 16, 414, DateTimeKind.Unspecified).AddTicks(4827), 45.0, 45.0 },
					{ new Guid("11111111-0000-0000-1111-111111111111"), new DateTime(2019, 6, 18, 11, 44, 16, 414, DateTimeKind.Unspecified).AddTicks(5836), 44.5, 44.5 },
					{ new Guid("11111111-0000-0000-1111-111111111111"), new DateTime(2019, 6, 18, 11, 44, 16, 414, DateTimeKind.Unspecified).AddTicks(6844), 44.0, 44.0 }
				});

			migrationBuilder.CreateIndex(
				name: "IX_AspNetRoleClaims_RoleId",
				table: "AspNetRoleClaims",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "RoleNameIndex",
				table: "AspNetRoles",
				column: "NormalizedName",
				unique: true,
				filter: "[NormalizedName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserClaims_UserId",
				table: "AspNetUserClaims",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserLogins_UserId",
				table: "AspNetUserLogins",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserRoles_RoleId",
				table: "AspNetUserRoles",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "EmailIndex",
				table: "AspNetUsers",
				column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				name: "UserNameIndex",
				table: "AspNetUsers",
				column: "NormalizedUserName",
				unique: true,
				filter: "[NormalizedUserName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_Flights_LogID",
				table: "Flights",
				column: "LogID",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Flights_UserID",
				table: "Flights",
				column: "UserID");

			migrationBuilder.CreateIndex(
				name: "IX_GPSLogs_LandingID",
				table: "GPSLogs",
				column: "LandingID");

			migrationBuilder.CreateIndex(
				name: "IX_GPSLogs_TakeoffID",
				table: "GPSLogs",
				column: "TakeoffID");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AspNetRoleClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserLogins");

			migrationBuilder.DropTable(
				name: "AspNetUserRoles");

			migrationBuilder.DropTable(
				name: "AspNetUserTokens");

			migrationBuilder.DropTable(
				name: "Flights");

			migrationBuilder.DropTable(
				name: "GPSLogEntries");

			migrationBuilder.DropTable(
				name: "AspNetRoles");

			migrationBuilder.DropTable(
				name: "AspNetUsers");

			migrationBuilder.DropTable(
				name: "GPSLogs");

			migrationBuilder.DropTable(
				name: "Airfields");
		}
	}
}
