using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    public partial class AddedAccessoars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ItemType identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Item type Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                },
                comment: "Item's type table");

            migrationBuilder.CreateTable(
                name: "Accessors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Accessor identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Accessor's name"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Accessor's price"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false, comment: "Accessor's type"),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Buyer identifier"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Accessor's state"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 60000, nullable: false, comment: "Accessor's image")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessors_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessors_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Accessories table");

            migrationBuilder.CreateTable(
                name: "AccessorsBuyers",
                columns: table => new
                {
                    AccessorId = table.Column<int>(type: "int", nullable: false, comment: "Accessor identifier"),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Buyer identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessorsBuyers", x => new { x.BuyerId, x.AccessorId });
                    table.ForeignKey(
                        name: "FK_AccessorsBuyers_Accessors_AccessorId",
                        column: x => x.AccessorId,
                        principalTable: "Accessors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessorsBuyers_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Accessors and buyers table");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"),
                column: "ConcurrencyStamp",
                value: "e94b4e0e-e2df-4961-954c-877c6fd47643");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "859fb265-c1ea-4b4c-9ef9-c5922d54d235", "AQAAAAEAACcQAAAAEDysbwfc0GLJgzj5TxGdAAGoogMXDAjQSek09ay+2YbZo31GIMKmAp1ED2mEBjEXMg==", "3E44E624-7ED2-49F4-9501-8BCA77027454" });

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: new DateTime(2024, 4, 9, 11, 56, 6, 897, DateTimeKind.Local).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: new DateTime(2024, 4, 9, 11, 56, 6, 897, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: new DateTime(2024, 4, 9, 11, 56, 6, 897, DateTimeKind.Local).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Year",
                value: new DateTime(2024, 4, 9, 11, 56, 6, 897, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Year",
                value: new DateTime(2024, 4, 9, 11, 56, 6, 897, DateTimeKind.Local).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Year",
                value: new DateTime(2024, 4, 9, 11, 56, 6, 897, DateTimeKind.Local).AddTicks(9762));

            migrationBuilder.CreateIndex(
                name: "IX_Accessors_BuyerId",
                table: "Accessors",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessors_ItemTypeId",
                table: "Accessors",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessorsBuyers_AccessorId",
                table: "AccessorsBuyers",
                column: "AccessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessorsBuyers");

            migrationBuilder.DropTable(
                name: "Accessors");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"),
                column: "ConcurrencyStamp",
                value: "29f1d54b-140e-44e5-870f-0a9f8c7486c9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8aa5c9b4-e438-47a6-93c4-9911ee52f72f", "AQAAAAEAACcQAAAAECvsBqYEcS5P6EPbC0Jsgi2vLimErKXm7eUEOwjk0NzDKA3hAkvx6jmzIa1t9KZeRQ==", "F16CC902-9EFF-461E-9FCA-54A9DBEBAEFB" });

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 35, 11, 782, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 35, 11, 782, DateTimeKind.Local).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 35, 11, 782, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 35, 11, 782, DateTimeKind.Local).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 35, 11, 782, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 35, 11, 782, DateTimeKind.Local).AddTicks(9979));
        }
    }
}
