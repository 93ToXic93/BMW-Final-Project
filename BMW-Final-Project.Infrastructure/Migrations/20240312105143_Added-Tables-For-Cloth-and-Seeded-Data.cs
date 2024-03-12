using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    public partial class AddedTablesForClothandSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "MotorcyclesBuyers",
                comment: "Motorcycles and buyers",
                oldComment: "Motorcycles and Buyers");

            migrationBuilder.CreateTable(
                name: "ClothCollections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Collection identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Collection Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothCollections", x => x.Id);
                },
                comment: "Season cloth collections");

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Size identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Size")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                },
                comment: "Size table");

            migrationBuilder.CreateTable(
                name: "TypesPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "TypePerson identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "TypePerson type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesPersons", x => x.Id);
                },
                comment: "TypePerson's table");

            migrationBuilder.CreateTable(
                name: "Cloths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Cloth identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Cloth name"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Cloth description"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 70000, nullable: false, comment: "Cloth image"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Cloth price"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Cloth status"),
                    Amount = table.Column<int>(type: "int", nullable: false, comment: "Cloth amount"),
                    ClothCollectionId = table.Column<int>(type: "int", nullable: false, comment: "Cloth collection identifier"),
                    SizeId = table.Column<int>(type: "int", nullable: false, comment: "Size identifier"),
                    TypePersonId = table.Column<int>(type: "int", nullable: false, comment: "TypePerson identifier"),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Buyer identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cloths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cloths_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cloths_ClothCollections_ClothCollectionId",
                        column: x => x.ClothCollectionId,
                        principalTable: "ClothCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cloths_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cloths_TypesPersons_TypePersonId",
                        column: x => x.TypePersonId,
                        principalTable: "TypesPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Cloth table");

            migrationBuilder.CreateTable(
                name: "ClothsBuyers",
                columns: table => new
                {
                    ClothId = table.Column<int>(type: "int", nullable: false, comment: "Cloth identifier"),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Buyer identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothsBuyers", x => new { x.BuyerId, x.ClothId });
                    table.ForeignKey(
                        name: "FK_ClothsBuyers_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClothsBuyers_Cloths_ClothId",
                        column: x => x.ClothId,
                        principalTable: "Cloths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Cloth and buyers");

            migrationBuilder.UpdateData(
                table: "ColorCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Черен");

            migrationBuilder.UpdateData(
                table: "ColorCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Бял");

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

            migrationBuilder.UpdateData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Евро-1");

            migrationBuilder.UpdateData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Евро-2");

            migrationBuilder.UpdateData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Евро-3");

            migrationBuilder.UpdateData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Евро-4");

            migrationBuilder.UpdateData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Евро-5");

            migrationBuilder.UpdateData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Евро-6");

            migrationBuilder.InsertData(
                table: "TypesPersons",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Мъже" },
                    { 2, "Жени" },
                    { 3, "Деца" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cloths_BuyerId",
                table: "Cloths",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cloths_ClothCollectionId",
                table: "Cloths",
                column: "ClothCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cloths_SizeId",
                table: "Cloths",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cloths_TypePersonId",
                table: "Cloths",
                column: "TypePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ClothsBuyers_ClothId",
                table: "ClothsBuyers",
                column: "ClothId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothsBuyers");

            migrationBuilder.DropTable(
                name: "Cloths");

            migrationBuilder.DropTable(
                name: "ClothCollections");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "TypesPersons");

            migrationBuilder.AlterTable(
                name: "MotorcyclesBuyers",
                comment: "Motorcycles and Buyers",
                oldComment: "Motorcycles and buyers");

            migrationBuilder.UpdateData(
                table: "ColorCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "White");

            migrationBuilder.UpdateData(
                table: "ColorCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Black");

            migrationBuilder.UpdateData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Euro-1");

            migrationBuilder.UpdateData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Euro-2");

            migrationBuilder.UpdateData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Euro-3");

            migrationBuilder.UpdateData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Euro-4");

            migrationBuilder.UpdateData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Euro-5");

            migrationBuilder.UpdateData(
                table: "StandardEuros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Euro-6");
        }
    }
}
