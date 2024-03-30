using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    public partial class SeedingCloth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 1,
                column: "Description",
                value: "Тениската е от 100% памук, качеството е гарантирано! Създадена е в Германия и е точната придобивка за лятото.");

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Якето е кожено и доста леко за вида му пропуска въздух с цел изягване на запотяване, произведено е в Германия.");

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Суитчера е от 100% памук и е доста лек и прохладен за горещото лято, произведен е в Германия.");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"),
                column: "ConcurrencyStamp",
                value: "93a95098-49a0-4ec6-846a-576f387dcb71");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5842c052-0ac2-4654-be9e-358bffb2addd", "AQAAAAEAACcQAAAAEMI+7jQWYZnWVQWfMTg+Z6jEX0kkm3+qs/hIFPCWjPn+oInIkWMAjpwhDa5bXhyTTw==", "8A16FD7B-C421-4295-8F91-E74197EBD539" });

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: new DateTime(2024, 3, 30, 3, 9, 33, 761, DateTimeKind.Local).AddTicks(4144));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: new DateTime(2024, 3, 30, 3, 9, 33, 761, DateTimeKind.Local).AddTicks(4189));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: new DateTime(2024, 3, 30, 3, 9, 33, 761, DateTimeKind.Local).AddTicks(4193));
        }
    }
}
