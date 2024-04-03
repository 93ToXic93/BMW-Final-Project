using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    public partial class SeededEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"),
                column: "ConcurrencyStamp",
                value: "1c8971e2-ea8c-453e-a824-7129319f4a42");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44d8604b-4b3d-46f4-a8dc-c72c085cdf7c", "AQAAAAEAACcQAAAAEH2GIevGfO7Q7ZuXw1G1tkl+jZ7F0369/tHaotFvaP0UugRo+E53AYllh9cH/jNCdQ==", "B060AE2D-55C6-4B36-BC6F-71F049CB4308" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndEvent", "JoinerId", "Name", "PlaceOfTheEvent", "StartEvent" },
                values: new object[] { 1, "Тази година само с БМВ ивента е неповторимо събитие, което на трябва да изпускате. Ще има стънт програма и екслузивни мотори. ЗАПОВЯДАЙТЕ!", new DateTime(2024, 4, 3, 14, 47, 12, 824, DateTimeKind.Local).AddTicks(3569), new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), "BMW SPORT EVENT", "София, BMW-България", new DateTime(2024, 4, 3, 14, 47, 12, 824, DateTimeKind.Local).AddTicks(3568) });

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 47, 12, 824, DateTimeKind.Local).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 47, 12, 824, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 47, 12, 824, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 4,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 47, 12, 824, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 47, 12, 824, DateTimeKind.Local).AddTicks(3539));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 47, 12, 824, DateTimeKind.Local).AddTicks(3545));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 47, 12, 824, DateTimeKind.Local).AddTicks(3548));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"),
                column: "ConcurrencyStamp",
                value: "4a82192b-eb88-406c-a6cf-d5f5b7d34d8d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6194ca4f-2a86-46ff-bf5e-09b7155ca823", "AQAAAAEAACcQAAAAEMRQGqhZVVa3XiDWz+RJg0AXRYJpsK5j18SGi1dZTp0SeMHD+goj2yYEnDJ+4gKG4w==", "B3367F26-E9B0-494B-86C9-3D8CAEF35478" });

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 39, 32, 775, DateTimeKind.Local).AddTicks(7007));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 39, 32, 775, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 39, 32, 775, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 4,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 39, 32, 775, DateTimeKind.Local).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 39, 32, 775, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 39, 32, 775, DateTimeKind.Local).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Year",
                value: new DateTime(2024, 4, 3, 14, 39, 32, 775, DateTimeKind.Local).AddTicks(7073));
        }
    }
}
