using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolarSchedule.AccessLayer.EntityFramework.Migrations
{
    public partial class firstblood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Userses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taskses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taskses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taskses_Userses_TaskKey",
                        column: x => x.TaskKey,
                        principalTable: "Userses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taskses_TaskKey",
                table: "Taskses",
                column: "TaskKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taskses");

            migrationBuilder.DropTable(
                name: "Userses");
        }
    }
}
