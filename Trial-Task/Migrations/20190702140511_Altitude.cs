using Microsoft.EntityFrameworkCore.Migrations;

namespace Trial_Task.Migrations
{
    public partial class Altitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Altitude",
                table: "GPSLogEntries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altitude",
                table: "GPSLogEntries");
        }
    }
}
