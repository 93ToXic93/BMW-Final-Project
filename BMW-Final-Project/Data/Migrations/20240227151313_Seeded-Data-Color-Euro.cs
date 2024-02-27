using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Data.Migrations
{
    public partial class SeededDataColorEuro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ColorCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ColorCategories",
                keyColumn: "Id",
                keyValue: 2);

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
                keyValue: 3);

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
        }
    }
}
