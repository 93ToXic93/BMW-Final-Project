using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Data.Migrations
{
    public partial class AddedMotorcycleTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColorCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Color identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Color Name"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorCategories", x => x.Id);
                },
                comment: "Color Table");

            migrationBuilder.CreateTable(
                name: "StandardEuros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Euro standard identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, comment: "Standard euro category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardEuros", x => x.Id);
                },
                comment: "Euro standard table");

            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Motorcycle model"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
                    BoughtOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of buying the motorcycle"),
                    Kg = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle weight"),
                    TankCapacity = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle tank capacity"),
                    HorsePowers = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle horse powers"),
                    CC = table.Column<int>(type: "int", nullable: false, comment: "Engine displacement"),
                    StandardEuroId = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle euro standard identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Motorcycle price"),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Motorcycle bought date and time"),
                    DTC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Motorcycle dynamic traction control"),
                    Transmission = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Motorcycle transmission box"),
                    FrontBreak = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Motorcycle front brake model"),
                    RearBreak = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Motorcycle rear brake model"),
                    SeatHeightMm = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle seat height in mm"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 70000, nullable: false, comment: "Motorcycle photo"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Motorcycle ad status"),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motorcycles_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motorcycles_ColorCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ColorCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motorcycles_StandardEuros_StandardEuroId",
                        column: x => x.StandardEuroId,
                        principalTable: "StandardEuros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Motorcycles table");

            migrationBuilder.CreateTable(
                name: "MotorcyclesBuyers",
                columns: table => new
                {
                    MotorcycleId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcyclesBuyers", x => new { x.BuyerId, x.MotorcycleId });
                    table.ForeignKey(
                        name: "FK_MotorcyclesBuyers_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MotorcyclesBuyers_Motorcycles_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_BuyerId",
                table: "Motorcycles",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_CategoryId",
                table: "Motorcycles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_StandardEuroId",
                table: "Motorcycles",
                column: "StandardEuroId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorcyclesBuyers_MotorcycleId",
                table: "MotorcyclesBuyers",
                column: "MotorcycleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotorcyclesBuyers");

            migrationBuilder.DropTable(
                name: "Motorcycles");

            migrationBuilder.DropTable(
                name: "ColorCategories");

            migrationBuilder.DropTable(
                name: "StandardEuros");
        }
    }
}
