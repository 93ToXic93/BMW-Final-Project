﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "ColorCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Color identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Color Name"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Color ad status")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorCategories", x => x.Id);
                },
                comment: "Color Table");

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ItemType identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Item type Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                },
                comment: "Item's type table");

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
                name: "StandardEuros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Euro standard identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, comment: "Standard euro category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardEuros", x => x.Id);
                },
                comment: "Euro standard table");

            migrationBuilder.CreateTable(
                name: "TypeMotor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Type identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Type name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMotor", x => x.Id);
                },
                comment: "Type of the motorcycle");

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    JoinerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Joiner identifier"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 60000, nullable: false)
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
                name: "Accessors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Accessor identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Accessor's name"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Accessor's price"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false, comment: "Accessor's type"),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Buyer identifier"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Accessor's state"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 60000, nullable: false, comment: "Accessor's image"),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessors_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessors_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Accessories table");

            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Motorcycle model"),
                    TypeMotorId = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle Type identifier"),
                    ColorCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
                    Kg = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle weight"),
                    TankCapacity = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle tank capacity"),
                    HorsePowers = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle horse powers"),
                    CC = table.Column<int>(type: "int", nullable: false, comment: "Engine displacement"),
                    StandardEuroId = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle euro standard identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Motorcycle price"),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Motorcycle bought date and time"),
                    DTC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Motorcycle dynamic traction control"),
                    Transmission = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Motorcycle transmission box"),
                    FrontBreak = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Motorcycle front brake model"),
                    RearBreak = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Motorcycle rear brake model"),
                    SeatHeightMm = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle seat height in mm"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 70000, nullable: false, comment: "Motorcycle photo"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Motorcycle ad status"),
                    Amount = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle amount"),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Buyer identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motorcycles_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motorcycles_ColorCategories_ColorCategoryId",
                        column: x => x.ColorCategoryId,
                        principalTable: "ColorCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motorcycles_StandardEuros_StandardEuroId",
                        column: x => x.StandardEuroId,
                        principalTable: "StandardEuros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motorcycles_TypeMotor_TypeMotorId",
                        column: x => x.TypeMotorId,
                        principalTable: "TypeMotor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Motorcycles table");

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
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Buyer identifier")
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

            migrationBuilder.CreateTable(
                name: "AccessorsBuyers",
                columns: table => new
                {
                    AccessorId = table.Column<int>(type: "int", nullable: false, comment: "Accessor identifier"),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Buyer identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessorsBuyers", x => new { x.BuyerId, x.AccessorId });
                    table.ForeignKey(
                        name: "FK_AccessorsBuyers_Accessors_AccessorId",
                        column: x => x.AccessorId,
                        principalTable: "Accessors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessorsBuyers_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Accessors and buyers table");

            migrationBuilder.CreateTable(
                name: "MotorcyclesBuyers",
                columns: table => new
                {
                    MotorcycleId = table.Column<int>(type: "int", nullable: false, comment: "Motorcycle identifier"),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Buyer identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcyclesBuyers", x => new { x.BuyerId, x.MotorcycleId });
                    table.ForeignKey(
                        name: "FK_MotorcyclesBuyers_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MotorcyclesBuyers_Motorcycles_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Motorcycles and buyers");

            migrationBuilder.CreateTable(
                name: "ClothsBuyers",
                columns: table => new
                {
                    ClothId = table.Column<int>(type: "int", nullable: false, comment: "Cloth identifier"),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Buyer identifier")
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"), "7e961b76-93af-483b-ab95-e519db26a089", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Nickname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 0, "97887623-b6d1-48ee-b17b-d0e1e4779b22", "Adi@gmail.com", false, "Adrian", "Ivanov", true, null, "ToXic", "ADI@GMAIL.COM", "ADI@GMAIL.COM", "AQAAAAEAACcQAAAAECiruepb7FVvM2W/UdNmEqj0AddBYnhLY/msy4ZY6Ue0jY4JkFfhQvJwDsQnnlmRew==", null, false, "F981F778-4B60-4C72-BAE4-293BC37204A4", false, "Adi@gmail.com" });

            migrationBuilder.InsertData(
                table: "ClothCollections",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Зимна колекция" },
                    { 2, "БМВ Origin колекция" },
                    { 3, "M-Колекция" }
                });

            migrationBuilder.InsertData(
                table: "ColorCategories",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Черен" },
                    { 2, true, "Бял" },
                    { 3, true, "Червен" },
                    { 4, true, "Жълт" },
                    { 5, true, "Лилав" },
                    { 6, true, "Бордо" },
                    { 7, true, "Светло-син" },
                    { 8, true, "Светло-жълт" },
                    { 9, true, "Светло-лилав" },
                    { 10, true, "Зелен" },
                    { 11, true, "Оранжев" }
                });

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
                    { 2, "Жени" }
                });

            migrationBuilder.InsertData(
                table: "TypesPersons",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Деца" });

            migrationBuilder.InsertData(
                table: "Accessors",
                columns: new[] { "Id", "Amount", "BuyerId", "ImgUrl", "IsActive", "ItemTypeId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), "https://www.donbaron.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/c/h/chanta-bmw-motorsport1_2_.jpg", true, 1, "Чанта BMW-MPower", 100m },
                    { 2, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), "https://s3.amazonaws.com/rparts-sites/images/285f89b802bcb2651801455c86d78f2a/8093df632b4ba5e7c90265f4c930b311.png", true, 2, "Флашка BMW-Black", 130m },
                    { 3, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), "https://www.igrachka.com/uploads/images/original/motor-injusa-s-bateriya-12v-bmw-r-1250-gs_143611.jpg", true, 3, "Детско моторче BMW-Black", 330m },
                    { 4, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), "https://cdn.shopify.com/s/files/1/0422/5191/1327/files/BMWMMOTORSPORTBOTTLE.jpg?v=1699006337&width=533", true, 1, "Бутилка BMW", 110m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"), new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9") });

            migrationBuilder.InsertData(
                table: "Cloths",
                columns: new[] { "Id", "Amount", "BuyerId", "ClothCollectionId", "Description", "ImgUrl", "IsActive", "Name", "Price", "SizeId", "TypePersonId" },
                values: new object[,]
                {
                    { 1, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 3, "Тениската е от 100% памук, качеството е гарантирано! Създадена е в Германия и е точната придобивка за лятото.", "https://bmwaccessories.ie/cdn/shop/products/80145A21737_3.jpg?v=1647336616&width=1445", true, "Тениска къс ръкав BMW-GO-SPEED", 60m, 3, 3 },
                    { 2, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 1, "Якето е кожено и доста леко за вида му пропуска въздух с цел изягване на запотяване, произведено е в Германия.", "https://www.dhresource.com/webp/m/0x0/f2/albu/g22/M00/41/9D/rBNaEmLG6pGASPeRAABoSHJIjxI746.jpg", true, "М-Power Лятно яке", 200m, 2, 1 },
                    { 3, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 2, "Суитчера е от 100% памук и е доста лек и прохладен за горещото лято, произведен е в Германия.", "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_600,h_600/global/596362/01/fnd/PNA/fmt/png/BMW-M-Motorsport-Women's-Hooded-Sweat-Jacket", true, "БМВ Оrigin суитшърт", 100m, 1, 2 },
                    { 4, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 3, "Тениската е от 100% памук и е доста лека и прохладна за горещото лято, произведена е в Германия.", "https://i.ebayimg.com/images/g/eCsAAOSwuz5j3pLA/s-l1200.webp", true, "БМВ Оrigin Тениска", 120m, 2, 1 },
                    { 5, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 2, "суитшърта е от 100% памук и е доста лек и прохладен за горещото лято, произведен е в Германия.", "https://img.fruugo.com/product/0/33/211450330_max.jpg", true, "БМВ Оrigin суитшърт", 70m, 1, 2 },
                    { 6, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 1, "Суитшърта е от 100% памук и е доста лек и прохладен за горещото лято, произведен е в Германия.", "https://i.pinimg.com/736x/cf/4a/03/cf4a031cad99e38a716ab99407c3cff3.jpg", true, "БМВ суитшърт", 100m, 5, 1 },
                    { 7, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 3, "Панталона е от 100% памук и е доста лек и прохладен за горещото лято, произведен е в Германия.", "https://webshop.motos-inghelbrecht.be/cdn/shop/files/bmw-motorbroek-aravisair-blauw.jpg?v=1705495106", true, "БМВ Панталон", 100m, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndEvent", "ImgUrl", "IsActive", "JoinerId", "Name", "PlaceOfTheEvent", "StartEvent" },
                values: new object[,]
                {
                    { 1, "Тази година само с BMW ,събитието ще бъде неповторимо, което не трябва да изпускате. Ще има стънт програма и екслузивни мотори. ЗАПОВЯДАЙТЕ!", new DateTime(2024, 2, 3, 19, 0, 0, 0, DateTimeKind.Unspecified), "https://www.bmw-motorrad.com/content/dam/bmwmotorradnsc/marketCORECOM/common/images/experience/stories/brand/bmd-2023/youtube/nsc-bmd-2023-youtube-fallback.jpg.asset.1675938793795.jpg", true, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), "BMW SPORT EVENT", "София, BMW-България", new DateTime(2024, 2, 2, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Тази година, BMW събитието ще бъде неповторимо, което не трябва да изпускате. Ще има стънт програма и екслузивни мотори.Това е 100-годишнината на BMW и желаем да поканим възможно повече хора! ЗАПОВЯДАЙТЕ!", new DateTime(2024, 1, 30, 21, 0, 0, 0, DateTimeKind.Unspecified), "https://i.ytimg.com/vi/2t-m6cuPUqI/maxresdefault.jpg", true, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), "BMW Anniversary", "София, BMW-България", new DateTime(2024, 1, 29, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "BMW - Откриване на сезона, желаем да Ви поканим да открием новият сезон с яркост и красота с нашите нови модели. ЗАПОВЯДАЙТЕ!", new DateTime(2024, 4, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), "https://c.ndtvimg.com/2020-09/9e7k4g2g_bmw-motorrad-days_625x300_18_September_20.jpg", true, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), "BMW new season", "София, BMW-България", new DateTime(2024, 4, 12, 11, 45, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Motorcycles",
                columns: new[] { "Id", "Amount", "BuyerId", "CC", "ColorCategoryId", "DTC", "FrontBreak", "HorsePowers", "ImageUrl", "IsActive", "Kg", "Model", "Price", "RearBreak", "SeatHeightMm", "StandardEuroId", "TankCapacity", "Transmission", "TypeMotorId", "Year" },
                values: new object[,]
                {
                    { 1, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 1000, 1, "BMW own Dynamic Traction Control specified for this unique bike", "BMW own Front Brake Control specified for this unique bike", 205, "https://images4.alphacoders.com/127/1277784.jpg", true, 197, "BMW S1000RR", 62000m, "BMW own Rear Brake Control specified for this unique bike", 705, 3, 21, "BMW 6-Gears transmission", 1, new DateTime(2024, 4, 9, 17, 56, 17, 820, DateTimeKind.Local).AddTicks(3566) },
                    { 2, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 900, 1, "BMW own Dynamic Traction Control specified for this unique bike", "BMW own Front Brake Control specified for this unique bike", 105, "https://storage.edidomus.it/dueruote/nuovo/850/lat1586861045333.jpg", true, 210, "BMW F900R", 32000m, "BMW own Rear Brake Control specified for this unique bike", 705, 3, 16, "BMW 6-Gears transmission", 4, new DateTime(2024, 4, 9, 17, 56, 17, 820, DateTimeKind.Local).AddTicks(3610) },
                    { 3, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 100, 1, "BMW own Dynamic Traction Control specified for this unique bike", "BMW own Front Brake Control specified for this unique bike", 225, "https://www.procycles.com.au/cdn/shop/files/2023-BMW-M-1000-RR_-16-1024x724.jpg?v=1689145146", true, 190, "BMW M1000RR", 82000m, "BMW own Rear Brake Control specified for this unique bike", 665, 3, 21, "BMW 6-Gears transmission", 2, new DateTime(2024, 4, 9, 17, 56, 17, 820, DateTimeKind.Local).AddTicks(3614) },
                    { 5, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 100, 1, "BMW own Dynamic Traction Control specified for this unique bike", "BMW own Front Brake Control specified for this unique bike", 225, "https://www.bavarianmc.co.za/files/bike/22767/img_20240205160754.jpg", true, 190, "BMW F800R", 82000m, "BMW own Rear Brake Control specified for this unique bike", 665, 3, 21, "BMW 6-Gears transmission", 3, new DateTime(2024, 4, 9, 17, 56, 17, 820, DateTimeKind.Local).AddTicks(3618) },
                    { 6, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 100, 1, "BMW own Dynamic Traction Control specified for this unique bike", "BMW own Front Brake Control specified for this unique bike", 225, "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgIT2nOwQjqBRnWlaEFM8TWukwdyvwvGoWtqhfRxAh2-lTgX1EH_l689He3V3mEj_vQQ1Dk0WK7JET62OW-THslCCRxTvn13NKzxRa6XwwM2yi-KAKY3qVeNfjLnoIB6zpA0cH2MFT4Ue7fQTc1NePPzIfcYZIB0beSzdhzY1THSaUq8sAYpOXLhjgA7A/s1074/2023-BMW-R-nineT-100-Years-and-R18-100-Years.jpg", true, 190, "BMW RNineT", 82000m, "BMW own Rear Brake Control specified for this unique bike", 665, 3, 21, "BMW 6-Gears transmission", 5, new DateTime(2024, 4, 9, 17, 56, 17, 820, DateTimeKind.Local).AddTicks(3621) },
                    { 7, 20, new Guid("32b13a0b-6546-439e-a40d-4880e8a4e0a9"), 100, 1, "BMW own Dynamic Traction Control specified for this unique bike", "BMW own Front Brake Control specified for this unique bike", 225, "https://cdn.dealerspike.com/imglib/v1/800x600/imglib/trimsdb/17432641-0-110420261.jpg", true, 190, "BMW R1250GS", 82000m, "BMW own Rear Brake Control specified for this unique bike", 665, 3, 21, "BMW 6-Gears transmission", 6, new DateTime(2024, 4, 9, 17, 56, 17, 820, DateTimeKind.Local).AddTicks(3624) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessors_BuyerId",
                table: "Accessors",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessors_ItemTypeId",
                table: "Accessors",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessorsBuyers_AccessorId",
                table: "AccessorsBuyers",
                column: "AccessorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_Events_JoinerId",
                table: "Events",
                column: "JoinerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsJoiners_EventId",
                table: "EventsJoiners",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_BuyerId",
                table: "Motorcycles",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_ColorCategoryId",
                table: "Motorcycles",
                column: "ColorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_StandardEuroId",
                table: "Motorcycles",
                column: "StandardEuroId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_TypeMotorId",
                table: "Motorcycles",
                column: "TypeMotorId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorcyclesBuyers_MotorcycleId",
                table: "MotorcyclesBuyers",
                column: "MotorcycleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessorsBuyers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClothsBuyers");

            migrationBuilder.DropTable(
                name: "EventsJoiners");

            migrationBuilder.DropTable(
                name: "MotorcyclesBuyers");

            migrationBuilder.DropTable(
                name: "Accessors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Cloths");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Motorcycles");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "ClothCollections");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "TypesPersons");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ColorCategories");

            migrationBuilder.DropTable(
                name: "StandardEuros");

            migrationBuilder.DropTable(
                name: "TypeMotor");
        }
    }
}