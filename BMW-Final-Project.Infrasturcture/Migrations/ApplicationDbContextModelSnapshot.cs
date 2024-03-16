﻿// <auto-generated />
using BMW_Final_Project.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace BMW_Final_Project.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Cloths.Cloth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Cloth identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasComment("Cloth amount");

                    b.Property<string>("BuyerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Buyer identifier");

                    b.Property<int>("ClothCollectionId")
                        .HasColumnType("int")
                        .HasComment("Cloth collection identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Cloth description");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasMaxLength(70000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Cloth image");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("Cloth status");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Cloth name");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Cloth price");

                    b.Property<int>("SizeId")
                        .HasColumnType("int")
                        .HasComment("Size identifier");

                    b.Property<int>("TypePersonId")
                        .HasColumnType("int")
                        .HasComment("TypePerson identifier");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ClothCollectionId");

                    b.HasIndex("SizeId");

                    b.HasIndex("TypePersonId");

                    b.ToTable("Cloths");

                    b.HasComment("Cloth table");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Cloths.ClothBuyer", b =>
                {
                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Buyer identifier");

                    b.Property<int>("ClothId")
                        .HasColumnType("int")
                        .HasComment("Cloth identifier");

                    b.HasKey("BuyerId", "ClothId");

                    b.HasIndex("ClothId");

                    b.ToTable("ClothsBuyers");

                    b.HasComment("Cloth and buyers");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Cloths.ClothCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Collection identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Collection Name");

                    b.HasKey("Id");

                    b.ToTable("ClothCollections");

                    b.HasComment("Season cloth collections");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Cloths.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Size identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Size");

                    b.HasKey("Id");

                    b.ToTable("Sizes");

                    b.HasComment("Size table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "XS"
                        },
                        new
                        {
                            Id = 2,
                            Name = "S"
                        },
                        new
                        {
                            Id = 3,
                            Name = "M"
                        },
                        new
                        {
                            Id = 4,
                            Name = "L"
                        },
                        new
                        {
                            Id = 5,
                            Name = "XL"
                        },
                        new
                        {
                            Id = 6,
                            Name = "XXL"
                        },
                        new
                        {
                            Id = 7,
                            Name = "XXXL"
                        });
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Cloths.TypePerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("TypePerson identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("TypePerson type");

                    b.HasKey("Id");

                    b.ToTable("TypesPersons");

                    b.HasComment("TypePerson's table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Мъже"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Жени"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Деца"
                        });
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.ColorCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Color identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("Color ad status");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Color Name");

                    b.HasKey("Id");

                    b.ToTable("ColorCategories");

                    b.HasComment("Color Table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Черен"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Бял"
                        });
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.Motorcycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Motorcycle identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasComment("Motorcycle amount");

                    b.Property<string>("BuyerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Buyer identifier");

                    b.Property<int>("CC")
                        .HasColumnType("int")
                        .HasComment("Engine displacement");

                    b.Property<int>("ColorCategoryId")
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    b.Property<string>("DTC")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Motorcycle dynamic traction control");

                    b.Property<string>("FrontBreak")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Motorcycle front brake model");

                    b.Property<int>("HorsePowers")
                        .HasColumnType("int")
                        .HasComment("Motorcycle horse powers");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(70000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Motorcycle photo");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("Motorcycle ad status");

                    b.Property<int>("Kg")
                        .HasColumnType("int")
                        .HasComment("Motorcycle weight");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Motorcycle model");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Motorcycle price");

                    b.Property<string>("RearBreak")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Motorcycle rear brake model");

                    b.Property<int>("SeatHeightMm")
                        .HasColumnType("int")
                        .HasComment("Motorcycle seat height in mm");

                    b.Property<int>("StandardEuroId")
                        .HasColumnType("int")
                        .HasComment("Motorcycle euro standard identifier");

                    b.Property<int>("TankCapacity")
                        .HasColumnType("int")
                        .HasComment("Motorcycle tank capacity");

                    b.Property<string>("Transmission")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Motorcycle transmission box");

                    b.Property<int>("TypeMotorId")
                        .HasColumnType("int")
                        .HasComment("Motorcycle Type identifier");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2")
                        .HasComment("Motorcycle bought date and time");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ColorCategoryId");

                    b.HasIndex("StandardEuroId");

                    b.HasIndex("TypeMotorId");

                    b.ToTable("Motorcycles");

                    b.HasComment("Motorcycles table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 20,
                            BuyerId = "42405069-32f4-4217-825e-a76dad984fc7",
                            CC = 1000,
                            ColorCategoryId = 1,
                            DTC = "BMW own Dynamic Traction Control specified for this unique bike",
                            FrontBreak = "BMW own Front Brake Control specified for this unique bike",
                            HorsePowers = 205,
                            ImageUrl = "https://images4.alphacoders.com/127/1277784.jpg",
                            IsActive = true,
                            Kg = 197,
                            Model = "BMW S1000RR",
                            Price = 62000m,
                            RearBreak = "BMW own Rear Brake Control specified for this unique bike",
                            SeatHeightMm = 705,
                            StandardEuroId = 3,
                            TankCapacity = 21,
                            Transmission = "BMW 6-Gears transmission",
                            TypeMotorId = 1,
                            Year = new DateTime(2024, 3, 12, 21, 28, 11, 242, DateTimeKind.Local).AddTicks(6353)
                        },
                        new
                        {
                            Id = 2,
                            Amount = 20,
                            BuyerId = "42405069-32f4-4217-825e-a76dad984fc7",
                            CC = 900,
                            ColorCategoryId = 1,
                            DTC = "BMW own Dynamic Traction Control specified for this unique bike",
                            FrontBreak = "BMW own Front Brake Control specified for this unique bike",
                            HorsePowers = 105,
                            ImageUrl = "https://storage.edidomus.it/dueruote/nuovo/850/lat1586861045333.jpg",
                            IsActive = true,
                            Kg = 210,
                            Model = "BMW F900R",
                            Price = 32000m,
                            RearBreak = "BMW own Rear Brake Control specified for this unique bike",
                            SeatHeightMm = 705,
                            StandardEuroId = 3,
                            TankCapacity = 16,
                            Transmission = "BMW 6-Gears transmission",
                            TypeMotorId = 4,
                            Year = new DateTime(2024, 3, 12, 21, 28, 11, 242, DateTimeKind.Local).AddTicks(6388)
                        },
                        new
                        {
                            Id = 3,
                            Amount = 20,
                            BuyerId = "42405069-32f4-4217-825e-a76dad984fc7",
                            CC = 100,
                            ColorCategoryId = 1,
                            DTC = "BMW own Dynamic Traction Control specified for this unique bike",
                            FrontBreak = "BMW own Front Brake Control specified for this unique bike",
                            HorsePowers = 225,
                            ImageUrl = "https://www.procycles.com.au/cdn/shop/files/2023-BMW-M-1000-RR_-16-1024x724.jpg?v=1689145146",
                            IsActive = true,
                            Kg = 190,
                            Model = "BMW M1000RR",
                            Price = 82000m,
                            RearBreak = "BMW own Rear Brake Control specified for this unique bike",
                            SeatHeightMm = 665,
                            StandardEuroId = 3,
                            TankCapacity = 21,
                            Transmission = "BMW 6-Gears transmission",
                            TypeMotorId = 2,
                            Year = new DateTime(2024, 3, 12, 21, 28, 11, 242, DateTimeKind.Local).AddTicks(6392)
                        });
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.MotorcycleBuyers", b =>
                {
                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Buyer identifier");

                    b.Property<int>("MotorcycleId")
                        .HasColumnType("int")
                        .HasComment("Motorcycle identifier");

                    b.HasKey("BuyerId", "MotorcycleId");

                    b.HasIndex("MotorcycleId");

                    b.ToTable("MotorcyclesBuyers");

                    b.HasComment("Motorcycles and buyers");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.StandardEuro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Euro standard identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasComment("Standard euro category");

                    b.HasKey("Id");

                    b.ToTable("StandardEuros");

                    b.HasComment("Euro standard table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Евро-1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Евро-2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Евро-3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Евро-4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Евро-5"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Евро-6"
                        });
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.TypeMotor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Type identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Type name");

                    b.HasKey("Id");

                    b.ToTable("TypeMotor");

                    b.HasComment("Type of the motorcycle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = 2,
                            Name = "M"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tour"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Roadster"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Heritage"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Urban Mobility"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "42405069-32f4-4217-825e-a76dad984fc7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8e926353-4d54-48da-b0f6-c79a71d78e5c",
                            Email = "Adi@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADI@GMAIL.COM",
                            NormalizedUserName = "ADI@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAENm8EjC/RzIWTB/V8XGUF3U3H5qt4KDqe6QoeypTHc8GrXcJPPt06yr1AFfR/Jc7wQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6c6c55c6-231e-40f3-bcec-b844a2719399",
                            TwoFactorEnabled = false,
                            UserName = "Adi@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Cloths.Cloth", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMW_Final_Project.Infrastructure.Data.Models.Cloths.ClothCollection", "ClothCollection")
                        .WithMany("Cloths")
                        .HasForeignKey("ClothCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMW_Final_Project.Infrastructure.Data.Models.Cloths.Size", "Size")
                        .WithMany("Cloths")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMW_Final_Project.Infrastructure.Data.Models.Cloths.TypePerson", "TypePerson")
                        .WithMany("Cloths")
                        .HasForeignKey("TypePersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("ClothCollection");

                    b.Navigation("Size");

                    b.Navigation("TypePerson");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Cloths.ClothBuyer", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BMW_Final_Project.Infrastructure.Data.Models.Cloths.Cloth", "Cloth")
                        .WithMany("ClothBuyers")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Cloth");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.Motorcycle", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.ColorCategory", "ColorCategory")
                        .WithMany("Motorcycles")
                        .HasForeignKey("ColorCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.StandardEuro", "StandardEuro")
                        .WithMany("Motorcycles")
                        .HasForeignKey("StandardEuroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.TypeMotor", "TypeMotor")
                        .WithMany("Motorcycles")
                        .HasForeignKey("TypeMotorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("ColorCategory");

                    b.Navigation("StandardEuro");

                    b.Navigation("TypeMotor");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.MotorcycleBuyers", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.Motorcycle", "Motorcycle")
                        .WithMany("MotorcycleBuyers")
                        .HasForeignKey("MotorcycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Motorcycle");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Cloths.Cloth", b =>
                {
                    b.Navigation("ClothBuyers");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Cloths.ClothCollection", b =>
                {
                    b.Navigation("Cloths");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Cloths.Size", b =>
                {
                    b.Navigation("Cloths");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Cloths.TypePerson", b =>
                {
                    b.Navigation("Cloths");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.ColorCategory", b =>
                {
                    b.Navigation("Motorcycles");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.Motorcycle", b =>
                {
                    b.Navigation("MotorcycleBuyers");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.StandardEuro", b =>
                {
                    b.Navigation("Motorcycles");
                });

            modelBuilder.Entity("BMW_Final_Project.Infrastructure.Data.Models.Motorcycles.TypeMotor", b =>
                {
                    b.Navigation("Motorcycles");
                });
#pragma warning restore 612, 618
        }
    }
}
