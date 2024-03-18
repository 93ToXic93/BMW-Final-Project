using BMW_Final_Project.Infrastructure.Data.IdentityModels;
using BMW_Final_Project.Infrastructure.Data.Models.Cloths;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
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

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = Guid.Parse("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                    UserName = "Adi@gmail.com",
                    NormalizedUserName = "ADI@GMAIL.COM",
                    Email = "Adi@gmail.com",
                    NormalizedEmail = "ADI@GMAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    TwoFactorEnabled = false,
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    AccessFailedCount = 0,
                    LockoutEnabled = true,
                    FirstName = "Adrian",
                    LastName = "Ivanov",
                    Nickname = "ToXic",
                    PasswordHash = hasher.HashPassword(null, "123456")
                });

            builder
                .Entity<ApplicationRole>()
                .HasData(new ApplicationRole
                {
                    Id = Guid.Parse("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5"),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

            builder
                .Entity<IdentityUserRole<Guid>>()
                .HasData(new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
                    RoleId = Guid.Parse("ab5f19c3-0e66-4a5b-ab4a-ada016abc5c5")
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
                }, new TypeMotor
                {
                    Id = 2,
                    Name = "M",
                }, new TypeMotor
                {
                    Id = 3,
                    Name = "Tour",
                }, new TypeMotor
                {
                    Id = 4,
                    Name = "Roadster",
                }, new TypeMotor
                {
                    Id = 5,
                    Name = "Heritage",
                }, new TypeMotor
                {
                    Id = 6,
                    Name = "Adventure",
                }, new TypeMotor
                {
                    Id = 7,
                    Name = "Urban Mobility",
                });


            builder
                .Entity<Motorcycle>()
                .HasData(new Motorcycle
                {
                    Id = 1,
                    Model = "BMW S1000RR",
                    TypeMotorId = 1,
                    Amount = 20,
                    CC = 1000,
                    StandardEuroId = 3,
                    Price = 62000,
                    Year = DateTime.Now,
                    BuyerId = Guid.Parse("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
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
                    CC = 900,
                    StandardEuroId = 3,
                    Price = 32000,
                    Year = DateTime.Now,
                    BuyerId = Guid.Parse("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
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
                    CC = 100,
                    StandardEuroId = 3,
                    Price = 82000,
                    Year = DateTime.Now,
                    BuyerId = Guid.Parse("32b13a0b-6546-439e-a40d-4880e8a4e0a9"),
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
