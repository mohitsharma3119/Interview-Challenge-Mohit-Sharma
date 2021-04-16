using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cox_Interview_Challenge_Mohit_Sharma.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dealerships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dealnumber = table.Column<int>(type: "int", nullable: false),
                    customername = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    dealershipName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    vehicle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealerships", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dealerships");
        }
    }
}
