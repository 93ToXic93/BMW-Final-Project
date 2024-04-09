using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    public partial class SeededeventData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "БМВ Оrigin суитшърт");

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "суитшърта е от 100% памук и е доста лек и прохладен за горещото лято, произведен е в Германия.", "БМВ Оrigin суитшърт" });

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Суитшърта е от 100% памук и е доста лек и прохладен за горещото лято, произведен е в Германия.", "БМВ суитшърт" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"),
                column: "ConcurrencyStamp",
                value: "0fc9ca9c-769a-4f7a-bae3-045f0573eccc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cb72572-cc66-4485-adb5-ad98f5bc098a", "AQAAAAEAACcQAAAAEEwfuBl0VrgMFWqb0EUZliETFpHhIVt3ymDa9CLyrdZzFvnD7LN9IlxziEhnwx00Rw==", "486079E5-439C-4151-8D41-43089B417AB4" });

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "БМВ Оrigin Суитчер");

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Суитчера е от 100% памук и е доста лек и прохладен за горещото лято, произведен е в Германия.", "БМВ Оrigin Суитчер" });

            migrationBuilder.UpdateData(
                table: "Cloths",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Суитчера е от 100% памук и е доста лек и прохладен за горещото лято, произведен е в Германия.", "БМВ Суитчер" });

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 17, 13, 681, DateTimeKind.Local).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 17, 13, 681, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 17, 13, 681, DateTimeKind.Local).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 17, 13, 681, DateTimeKind.Local).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 17, 13, 681, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 17, 13, 681, DateTimeKind.Local).AddTicks(4583));
        }
    }
}
