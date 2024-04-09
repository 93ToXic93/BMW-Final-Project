using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    public partial class AccessoarsSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"),
                column: "ConcurrencyStamp",
                value: "d96f1584-bc96-42cf-9b43-652d7478f220");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7badb3c-f8ca-4e8f-a1c2-1579bbf1e413", "AQAAAAEAACcQAAAAEAUGo9yN2zjkX1kTm/K+raNHIRUIqVNuTHkVTlGdlpxqwOwM9XHMCX09w3rC5iI9Fg==", "55E78619-6203-417F-B33B-573DF3DDBA2E" });

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ежедневни" },
                    { 2, "Електронни" },
                    { 3, "Играчки" },
                    { 4, "Други" }
                });

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: new DateTime(2024, 4, 9, 12, 10, 2, 355, DateTimeKind.Local).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: new DateTime(2024, 4, 9, 12, 10, 2, 355, DateTimeKind.Local).AddTicks(3700));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: new DateTime(2024, 4, 9, 12, 10, 2, 355, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Year",
                value: new DateTime(2024, 4, 9, 12, 10, 2, 355, DateTimeKind.Local).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Year",
                value: new DateTime(2024, 4, 9, 12, 10, 2, 355, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Year",
                value: new DateTime(2024, 4, 9, 12, 10, 2, 355, DateTimeKind.Local).AddTicks(3715));

            migrationBuilder.InsertData(
                table: "Accessors",
                columns: new[] { "Id", "BuyerId", "ImgUrl", "IsActive", "ItemTypeId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), "https://www.donbaron.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/c/h/chanta-bmw-motorsport1_2_.jpg", true, 1, "Чанта BMW-MPower", 100m },
                    { 2, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), "https://s3.amazonaws.com/rparts-sites/images/285f89b802bcb2651801455c86d78f2a/8093df632b4ba5e7c90265f4c930b311.png", true, 2, "Флашка BMW-Black", 130m },
                    { 3, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), "https://www.igrachka.com/uploads/images/original/motor-injusa-s-bateriya-12v-bmw-r-1250-gs_143611.jpg", true, 3, "Детско моторче BMW-Black", 330m },
                    { 4, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), "https://cdn.shopify.com/s/files/1/0422/5191/1327/files/BMWMMOTORSPORTBOTTLE.jpg?v=1699006337&width=533", true, 4, "Бутилка BMW", 110m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accessors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accessors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accessors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accessors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 4);

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
        }
    }
}
