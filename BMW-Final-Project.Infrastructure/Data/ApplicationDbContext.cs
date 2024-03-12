using BMW_Final_Project.Infrastructure.Data.Models.Cloths;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycles;
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
                },
                    new TypeMotor
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


            base.OnModelCreating(builder);
        }
    }
}
