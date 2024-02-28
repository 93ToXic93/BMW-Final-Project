using BMW_Final_Project.Infrastructure.Data.Models;
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


            builder
                .Entity<ColorCategory>()
                .HasData(new ColorCategory
                {
                    Id = 1,
                    Name = "White",
                    IsActive = true
                },
                    new ColorCategory
                    {
                        Id = 2,
                        Name = "Black",
                        IsActive = true
                    });


            builder
                .Entity<StandardEuro>()
                .HasData(new StandardEuro
                {
                    Id = 1,
                    Name = "Euro-1",
                },
                    new StandardEuro
                    {
                        Id = 2,
                        Name = "Euro-2",
                    }, new StandardEuro
                    {
                        Id = 3,
                        Name = "Euro-3",
                    }, new StandardEuro
                    {
                        Id = 4,
                        Name = "Euro-4",
                    }, new StandardEuro
                    {
                        Id = 5,
                        Name = "Euro-5",
                    }, new StandardEuro
                    {
                        Id = 6,
                        Name = "Euro-6",
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
