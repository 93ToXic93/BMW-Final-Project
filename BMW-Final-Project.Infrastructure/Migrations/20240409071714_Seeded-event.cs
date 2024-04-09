using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    public partial class Seededevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Тази година само с BMW ,събитието ще бъде неповторимо, което не трябва да изпускате. Ще има стънт програма и екслузивни мотори. ЗАПОВЯДАЙТЕ!");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Тази година, BMW събитието ще бъде неповторимо, което не трябва да изпускате. Ще има стънт програма и екслузивни мотори.Това е 100-годишнината на BMW и желаем да поканим възможно повече хора! ЗАПОВЯДАЙТЕ!");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "BMW - Откриване на сезона, желаем да Ви поканим да открием новият сезон с яркост и красота с нашите нови модели. ЗАПОВЯДАЙТЕ!");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"),
                column: "ConcurrencyStamp",
                value: "ecdbb273-bd10-441d-9ecc-2273116a2ad3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc3932bc-1975-41b9-bfbd-9a5e3026b3b2", "AQAAAAEAACcQAAAAEKAQk7xw0wEmDlguT56zLkqSIpSigU2HibA6JsMX7Lof9yRK4/cgKemXbo4H9P7zbA==", "AB5A821E-B747-4C2D-B4E6-97C9C10F68DD" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Тази година само с БМВ ивента е неповторимо събитие, което на трябва да изпускате. Ще има стънт програма и екслузивни мотори. ЗАПОВЯДАЙТЕ!");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Тази година, БМВ ивента е неповторимо събитие, което на трябва да изпускате. Ще има стънт програма и екслузивни мотори.Това е 100-годишнината на BMW и желаем да поканим възможно повече хора! ЗАПОВЯДАЙТЕ!");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "BMW - Откриване на сезона, желаем да ви поканим да открием новият сезон с яркост и красота с нашите нови модели. ЗАПОВЯДАЙТЕ!");

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 11, 54, 260, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 11, 54, 260, DateTimeKind.Local).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 11, 54, 260, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 11, 54, 260, DateTimeKind.Local).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 11, 54, 260, DateTimeKind.Local).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Year",
                value: new DateTime(2024, 4, 9, 10, 11, 54, 260, DateTimeKind.Local).AddTicks(2222));
        }
    }
}
