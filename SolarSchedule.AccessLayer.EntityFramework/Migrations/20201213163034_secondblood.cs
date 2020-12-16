using Microsoft.EntityFrameworkCore.Migrations;

namespace SolarSchedule.AccessLayer.EntityFramework.Migrations
{
    public partial class secondblood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Userses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Userses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Userses");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Userses");
        }
    }
}
