using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    public partial class AddEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Event identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the event"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Description of the event"),
                    StartEvent = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date of the event"),
                    EndEvent = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "End date of the event"),
                    PlaceOfTheEvent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Place date of the event"),
                    JoinerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Joiner identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_JoinerId",
                        column: x => x.JoinerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Cloth table");

            migrationBuilder.CreateTable(
                name: "EventsJoiners",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false, comment: "Event identifier"),
                    JoinerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Joiner identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsJoiners", x => new { x.JoinerId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventsJoiners_AspNetUsers_JoinerId",
                        column: x => x.JoinerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventsJoiners_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Events and joiners");

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

            migrationBuilder.CreateIndex(
                name: "IX_Events_JoinerId",
                table: "Events",
                column: "JoinerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsJoiners_EventId",
                table: "EventsJoiners",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsJoiners");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"),
                column: "ConcurrencyStamp",
                value: "1d9d7420-540f-4481-8eec-eeaa344cfc67");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e0df3dd-9350-4bd3-a16a-f1b0f5f85322", "AQAAAAEAACcQAAAAECIN+AC3Jp1y4pClNht2B46q+32wfUEOeS9WIuSopz7rCkLwhy/3qzJJRKi9LetYcg==", "0596E55F-30F6-4B71-AC43-297D284AD145" });

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: new DateTime(2024, 4, 3, 0, 24, 27, 444, DateTimeKind.Local).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: new DateTime(2024, 4, 3, 0, 24, 27, 444, DateTimeKind.Local).AddTicks(2067));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: new DateTime(2024, 4, 3, 0, 24, 27, 444, DateTimeKind.Local).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 4,
                column: "Year",
                value: new DateTime(2024, 4, 3, 0, 24, 27, 444, DateTimeKind.Local).AddTicks(2075));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Year",
                value: new DateTime(2024, 4, 3, 0, 24, 27, 444, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Year",
                value: new DateTime(2024, 4, 3, 0, 24, 27, 444, DateTimeKind.Local).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Year",
                value: new DateTime(2024, 4, 3, 0, 24, 27, 444, DateTimeKind.Local).AddTicks(2085));
        }
    }
}
