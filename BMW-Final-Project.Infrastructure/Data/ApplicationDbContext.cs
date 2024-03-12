using BMW_Final_Project.Infrastructure.Data.Models.Cloths;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MotorcycleBuyers> MotorcyclesBuyers { get; set; } = null!;
        public DbSet<Motorcycle> Motorcycles { get; set; } = null!;
        public DbSet<StandardEuro> StandardEuros { get; set; } = null!;
        public DbSet<ColorCategory> ColorCategories { get; set; } = null!;

        public DbSet<Cloth> Cloths { get; set; } = null!;
        public DbSet<ClothBuyer> ClothsBuyers { get; set; } = null!;
        public DbSet<TypePerson> TypesPersons { get; set; } = null!;
        public DbSet<Size> Sizes { get; set; } = null!;
        public DbSet<ClothCollection> ClothCollections { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MotorcycleBuyers>()
                .HasKey(x => new { x.BuyerId, x.MotorcycleId });

            builder.Entity<Motorcycle>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);

            builder.Entity<MotorcycleBuyers>()
                .HasOne(x => x.Buyer)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ClothBuyer>()
                .HasKey(x => new { x.BuyerId, x.ClothId });

            builder.Entity<Cloth>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);

            builder.Entity<ClothBuyer>()
                .HasOne(x => x.Buyer)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<IdentityUser>()
                .HasData(new IdentityUser()
                {
                    Email = "Adi@gmail.com",
                    EmailConfirmed = true,
                    Id = "42405069-32f4-4217-825e-a76dad984fc7",
                    NormalizedEmail = "Adi@gmail.com".ToUpper(),
                    NormalizedUserName = "Adi@gmail.com".ToUpper(),
                    PasswordHash = "AQAAAAEAACcQAAAAENm8EjC/RzIWTB/V8XGUF3U3H5qt4KDqe6QoeypTHc8GrXcJPPt06yr1AFfR/Jc7wQ==",
                    UserName = "Adi@gmail.com"
                });

            builder
                .Entity<TypePerson>()
                .HasData(new TypePerson()
                {
                    Id = 1,
                    Name = "Мъже",
                },
                    new TypePerson
                    {
                        Id = 2,
                        Name = "Жени",
                    }, new TypePerson
                    {
                        Id = 3,
                        Name = "Деца",
                    });


            builder
                .Entity<Size>()
                .HasData(new Size
                {
                    Id = 1,
                    Name = "XS",
                },
                    new Size
                    {
                        Id = 2,
                        Name = "S",
                    }, new Size
                    {
                        Id = 3,
                        Name = "M",
                    },
                    new Size
                    {
                        Id = 4,
                        Name = "L",
                    },
                    new Size
                    {
                        Id = 5,
                        Name = "XL",
                    }, new Size
                    {
                        Id = 6,
                        Name = "XXL",
                    }, new Size
                    {
                        Id = 7,
                        Name = "XXXL",
                    });




            builder
                .Entity<ColorCategory>()
                .HasData(new ColorCategory
                {
                    Id = 1,
                    Name = "Черен",
                    IsActive = true
                },
                    new ColorCategory
                    {
                        Id = 2,
                        Name = "Бял",
                        IsActive = true
                    });


            builder
                .Entity<StandardEuro>()
                .HasData(new StandardEuro
                {
                    Id = 1,
                    Name = "Евро-1",
                },
                    new StandardEuro
                    {
                        Id = 2,
                        Name = "Евро-2",
                    }, new StandardEuro
                    {
                        Id = 3,
                        Name = "Евро-3",
                    }, new StandardEuro
                    {
                        Id = 4,
                        Name = "Евро-4",
                    }, new StandardEuro
                    {
                        Id = 5,
                        Name = "Евро-5",
                    }, new StandardEuro
                    {
                        Id = 6,
                        Name = "Евро-6",
                    });


            builder
                .Entity<TypeMotor>()
                .HasData(new TypeMotor
                {
                    Id = 1,
                    Name = "Sport",
                    IsActive = true
                }, new TypeMotor
                {
                    Id = 2,
                    Name = "M",
                    IsActive = true

                }, new TypeMotor
                {
                    Id = 3,
                    Name = "Tour",
                    IsActive = true

                }, new TypeMotor
                {
                    Id = 4,
                    Name = "Roadster",
                    IsActive = true

                }, new TypeMotor
                {
                    Id = 5,
                    Name = "Heritage",
                    IsActive = true

                }, new TypeMotor
                {
                    Id = 6,
                    Name = "Adventure",
                    IsActive = true

                }, new TypeMotor
                {
                    Id = 7,
                    Name = "Urban Mobility",
                    IsActive = true

                });


            builder
                .Entity<Motorcycle>()
                .HasData(new Motorcycle
                {
                    Id = 1,
                    Model = "BMW S1000RR",
                    TypeMotorId = 1,
                    Amount = 20,
                    BuyerId = "42405069-32f4-4217-825e-a76dad984fc7",
                    CC = 1000,
                    StandardEuroId = 3,
                    Price = 62000,
                    Year = DateTime.Now,
                    ColorCategoryId = 1,
                    Kg = 197,
                    TankCapacity = 21,
                    DTC = "BMW own Dynamic Traction Control specified for this unique bike",
                    Transmission = "BMW 6-Gears transmission",
                    FrontBreak = "BMW own Front Brake Control specified for this unique bike",
                    RearBreak = "BMW own Rear Brake Control specified for this unique bike",
                    SeatHeightMm = 705,
                    ImageUrl = "https://images4.alphacoders.com/127/1277784.jpg",
                    IsActive = true,
                    HorsePowers = 205,

                }, new Motorcycle()
                {
                    Id = 2,
                    Model = "BMW F900R",
                    TypeMotorId = 4,
                    Amount = 20,
                    BuyerId = "42405069-32f4-4217-825e-a76dad984fc7",
                    CC = 900,
                    StandardEuroId = 3,
                    Price = 32000,
                    Year = DateTime.Now,
                    ColorCategoryId = 1,
                    Kg = 210,
                    TankCapacity = 16,
                    DTC = "BMW own Dynamic Traction Control specified for this unique bike",
                    Transmission = "BMW 6-Gears transmission",
                    FrontBreak = "BMW own Front Brake Control specified for this unique bike",
                    RearBreak = "BMW own Rear Brake Control specified for this unique bike",
                    SeatHeightMm = 705,
                    ImageUrl = "https://storage.edidomus.it/dueruote/nuovo/850/lat1586861045333.jpg",
                    IsActive = true,
                    HorsePowers = 105,
                }, new Motorcycle()
                {
                    Id = 3,
                    Model = "BMW M1000RR",
                    TypeMotorId = 2,
                    Amount = 20,
                    BuyerId = "42405069-32f4-4217-825e-a76dad984fc7",
                    CC = 100,
                    StandardEuroId = 3,
                    Price = 82000,
                    Year = DateTime.Now,
                    ColorCategoryId = 1,
                    Kg = 190,
                    TankCapacity = 21,
                    DTC = "BMW own Dynamic Traction Control specified for this unique bike",
                    Transmission = "BMW 6-Gears transmission",
                    FrontBreak = "BMW own Front Brake Control specified for this unique bike",
                    RearBreak = "BMW own Rear Brake Control specified for this unique bike",
                    SeatHeightMm = 665,
                    ImageUrl = "https://www.procycles.com.au/cdn/shop/files/2023-BMW-M-1000-RR_-16-1024x724.jpg?v=1689145146",
                    IsActive = true,
                    HorsePowers = 225,
                });




            base.OnModelCreating(builder);
        }
    }
}
