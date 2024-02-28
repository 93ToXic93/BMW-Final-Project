using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Color identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Color Name"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Color ad status")
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
                name: "TypeMotor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Type identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Type name"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Type ad status")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMotor", x => x.Id);
                },
                comment: "Type of the motorcycle");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Motorcycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Motorcycle model"),
                    TypeMotorId = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle Type identifier"),
                    ColorCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
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
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Buyer identifier"),
                    Amount = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle amount")
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
                        name: "FK_Motorcycles_ColorCategories_ColorCategoryId",
                        column: x => x.ColorCategoryId,
                        principalTable: "ColorCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motorcycles_StandardEuros_StandardEuroId",
                        column: x => x.StandardEuroId,
                        principalTable: "StandardEuros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motorcycles_TypeMotor_TypeMotorId",
                        column: x => x.TypeMotorId,
                        principalTable: "TypeMotor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Motorcycles table");

            migrationBuilder.CreateTable(
                name: "MotorcyclesBuyers",
                columns: table => new
                {
                    MotorcycleId = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle identifier"),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Buyer identifier")
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
                },
                comment: "Motorcycles and Buyers");

            migrationBuilder.InsertData(
                table: "ColorCategories",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "White" },
                    { 2, true, "Black" }
                });

            migrationBuilder.InsertData(
                table: "StandardEuros",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Euro-1" },
                    { 2, "Euro-2" },
                    { 3, "Euro-3" },
                    { 4, "Euro-4" },
                    { 5, "Euro-5" },
                    { 6, "Euro-6" }
                });

            migrationBuilder.InsertData(
                table: "TypeMotor",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Sport" },
                    { 2, true, "M" },
                    { 3, true, "Tour" },
                    { 4, true, "Roadster" },
                    { 5, true, "Heritage" },
                    { 6, true, "Adventure" },
                    { 7, true, "Urban Mobility" }
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
                name: "IX_Motorcycles_BuyerId",
                table: "Motorcycles",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_ColorCategoryId",
                table: "Motorcycles",
                column: "ColorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_StandardEuroId",
                table: "Motorcycles",
                column: "StandardEuroId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_TypeMotorId",
                table: "Motorcycles",
                column: "TypeMotorId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorcyclesBuyers_MotorcycleId",
                table: "MotorcyclesBuyers",
                column: "MotorcycleId");
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
                name: "MotorcyclesBuyers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Motorcycles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ColorCategories");

            migrationBuilder.DropTable(
                name: "StandardEuros");

            migrationBuilder.DropTable(
                name: "TypeMotor");
        }
    }
}
