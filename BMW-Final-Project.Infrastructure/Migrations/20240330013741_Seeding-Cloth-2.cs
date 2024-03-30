using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    public partial class SeedingCloth2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"),
                column: "ConcurrencyStamp",
                value: "ebe4a756-c37e-425c-b3bf-c8a2f45fca7e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71261d54-d13a-4fef-a78a-072883f90f12", "AQAAAAEAACcQAAAAECBHvXNdb6pjT9QYUp4aNaXxI3+/V3UwY6cjr1ujkOnIYfhn2jwZb7c5H9YBv+4DuQ==", "E75BEFC6-C6AE-41D8-B636-D57CD42B816C" });

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 2,
                column: "SizeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 3,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: new DateTime(2024, 3, 30, 3, 37, 41, 188, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: new DateTime(2024, 3, 30, 3, 37, 41, 188, DateTimeKind.Local).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: new DateTime(2024, 3, 30, 3, 37, 41, 188, DateTimeKind.Local).AddTicks(278));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"),
                column: "ConcurrencyStamp",
                value: "fa7310ac-5dea-4e11-accc-97b6cd78476c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61b007c8-04d1-4253-9686-fd787d6482ca", "AQAAAAEAACcQAAAAEHqvTya5VQuKxkCb9lC+4+TQwZrsnMas9ehRV1FWkYrt/f5hiV0tWMIX0keZV8++Pg==", "4A18B788-A9AC-4490-ACBD-E9F6D0CFEF16" });

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 2,
                column: "SizeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 3,
                column: "SizeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: new DateTime(2024, 3, 30, 3, 33, 39, 793, DateTimeKind.Local).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: new DateTime(2024, 3, 30, 3, 33, 39, 793, DateTimeKind.Local).AddTicks(5526));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: new DateTime(2024, 3, 30, 3, 33, 39, 793, DateTimeKind.Local).AddTicks(5530));
        }
    }
}
