using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Services;
using BMW_Final_Project.Infrastructure.Data;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data.IdentityModels;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IMotorcycleService, MotorcycleService>();
            services.AddScoped<IClothService, ClothService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IAccessoriesService, AccessoriesService>();

            return services;
        }
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));


            return services;
        }
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.User.RequireUniqueEmail = true;
                })
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
        public static IServiceCollection AddApplicationAuthentication(this IServiceCollection services)
        {
            services
                .ConfigureApplicationCookie(options =>
                {
                    options.AccessDeniedPath = PathString.FromUriComponent("/Home/Error?statusCode={0}");
                });

            return services;
        }

    }
}
