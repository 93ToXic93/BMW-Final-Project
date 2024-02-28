using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Data.Migrations
{
    public partial class UpdatedsometablesseededTypeMotorcycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_ColorCategories_CategoryId",
                table: "Motorcycles");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Motorcycles",
                newName: "ColorCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Motorcycles_CategoryId",
                table: "Motorcycles",
                newName: "IX_Motorcycles_ColorCategoryId");

            migrationBuilder.AlterTable(
                name: "MotorcyclesBuyers",
                comment: "Motorcycles and Buyers");

            migrationBuilder.AlterColumn<int>(
                name: "MotorcycleId",
                table: "MotorcyclesBuyers",
                type: "int",
                nullable: false,
                comment: "Motorcycle identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "MotorcyclesBuyers",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Buyer identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "TypeMotorId",
                table: "Motorcycles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Motorcycle Type identifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ColorCategories",
                type: "bit",
                nullable: false,
                comment: "Color ad status",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "TypeMotor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Type identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Type name"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Type ad status")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMotor", x => x.Id);
                },
                comment: "Type of the motorcycle");

            migrationBuilder.InsertData(
                table: "TypeMotor",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Sport" },
                    { 2, true, "M" },
                    { 3, true, "Tour" },
                    { 4, true, "Roadster" },
                    { 5, true, "Heritage" },
                    { 6, true, "Adventure" },
                    { 7, true, "Urban Mobility" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_TypeMotorId",
                table: "Motorcycles",
                column: "TypeMotorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_ColorCategories_ColorCategoryId",
                table: "Motorcycles",
                column: "ColorCategoryId",
                principalTable: "ColorCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_TypeMotor_TypeMotorId",
                table: "Motorcycles",
                column: "TypeMotorId",
                principalTable: "TypeMotor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_ColorCategories_ColorCategoryId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_TypeMotor_TypeMotorId",
                table: "Motorcycles");

            migrationBuilder.DropTable(
                name: "TypeMotor");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_TypeMotorId",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "TypeMotorId",
                table: "Motorcycles");

            migrationBuilder.RenameColumn(
                name: "ColorCategoryId",
                table: "Motorcycles",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Motorcycles_ColorCategoryId",
                table: "Motorcycles",
                newName: "IX_Motorcycles_CategoryId");

            migrationBuilder.AlterTable(
                name: "MotorcyclesBuyers",
                oldComment: "Motorcycles and Buyers");

            migrationBuilder.AlterColumn<int>(
                name: "MotorcycleId",
                table: "MotorcyclesBuyers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Motorcycle identifier");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "MotorcyclesBuyers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Buyer identifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ColorCategories",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Color ad status");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_ColorCategories_CategoryId",
                table: "Motorcycles",
                column: "CategoryId",
                principalTable: "ColorCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
