using BMW_Final_Project.Infrastructure.Data;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection AddAplicationDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            return services;
        }
        public static IServiceCollection AddAplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }

    }
}
