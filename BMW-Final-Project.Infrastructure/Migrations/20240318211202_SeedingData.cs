using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"), "231294f2-711e-4375-b0ad-24a0afb2ca49", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Nickname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 0, "b2a2e494-1e6b-4506-bc62-b9d64d733bcc", "Adi@gmail.com", false, "Adrian", "Ivanov", true, null, "ToXic", "ADI@GMAIL.COM", "ADI@GMAIL.COM", "AQAAAAEAACcQAAAAEI3QtfajC/20tDwfiPUotrnRFmEHiDOX94A8vBX98WkoD40TPRsKlcZ/VJUHNSOdsg==", null, false, "F75F20C0-D284-4940-BC8B-5DAB4DD73C0B", false, "Adi@gmail.com" });

            migrationBuilder.InsertData(
                table: "ColorCategories",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Черен" },
                    { 2, true, "Бял" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "XS" },
                    { 2, "S" },
                    { 3, "M" },
                    { 4, "L" },
                    { 5, "XL" },
                    { 6, "XXL" },
                    { 7, "XXXL" }
                });

            migrationBuilder.InsertData(
                table: "StandardEuros",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Евро-1" },
                    { 2, "Евро-2" },
                    { 3, "Евро-3" },
                    { 4, "Евро-4" },
                    { 5, "Евро-5" },
                    { 6, "Евро-6" }
                });

            migrationBuilder.InsertData(
                table: "TypeMotor",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sport" },
                    { 2, "M" },
                    { 3, "Tour" },
                    { 4, "Roadster" },
                    { 5, "Heritage" },
                    { 6, "Adventure" },
                    { 7, "Urban Mobility" }
                });

            migrationBuilder.InsertData(
                table: "TypesPersons",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Мъже" },
                    { 2, "Жени" },
                    { 3, "Деца" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"), new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9") });

            migrationBuilder.InsertData(
                table: "Motorcycles",
                columns: new[] { "Id", "Amount", "BuyerId", "CC", "ColorCategoryId", "DTC", "FrontBreak", "HorsePowers", "ImageUrl", "IsActive", "Kg", "Model", "Price", "RearBreak", "SeatHeightMm", "StandardEuroId", "TankCapacity", "Transmission", "TypeMotorId", "Year" },
                values: new object[,]
                {
                    { 1, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 1000, 1, "BMW own Dynamic Traction Control specified for this unique bike", "BMW own Front Brake Control specified for this unique bike", 205, "https://images4.alphacoders.com/127/1277784.jpg", true, 197, "BMW S1000RR", 62000m, "BMW own Rear Brake Control specified for this unique bike", 705, 3, 21, "BMW 6-Gears transmission", 1, new DateTime(2024, 3, 18, 23, 12, 1, 967, DateTimeKind.Local).AddTicks(7000) },
                    { 2, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 900, 1, "BMW own Dynamic Traction Control specified for this unique bike", "BMW own Front Brake Control specified for this unique bike", 105, "https://storage.edidomus.it/dueruote/nuovo/850/lat1586861045333.jpg", true, 210, "BMW F900R", 32000m, "BMW own Rear Brake Control specified for this unique bike", 705, 3, 16, "BMW 6-Gears transmission", 4, new DateTime(2024, 3, 18, 23, 12, 1, 967, DateTimeKind.Local).AddTicks(7047) },
                    { 3, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 100, 1, "BMW own Dynamic Traction Control specified for this unique bike", "BMW own Front Brake Control specified for this unique bike", 225, "https://www.procycles.com.au/cdn/shop/files/2023-BMW-M-1000-RR_-16-1024x724.jpg?v=1689145146", true, 190, "BMW M1000RR", 82000m, "BMW own Rear Brake Control specified for this unique bike", 665, 3, 21, "BMW 6-Gears transmission", 2, new DateTime(2024, 3, 18, 23, 12, 1, 967, DateTimeKind.Local).AddTicks(7051) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"), new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9") });

            migrationBuilder.DeleteData(
                table: "ColorCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TypeMotor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TypeMotor",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TypeMotor",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TypeMotor",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TypesPersons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypesPersons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypesPersons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"));

            migrationBuilder.DeleteData(
                table: "ColorCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TypeMotor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeMotor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypeMotor",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
