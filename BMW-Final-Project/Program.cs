using BMW_Final_Project.Core.Contracts;
using BMW_Final_Project.Core.Services;
using BMW_Final_Project.Extensions;
using BMW_Final_Project.ModelBinders;

namespace BMW_Final_Project
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAplicationDbContext(builder.Configuration);
            builder.Services.AddAplicationIdentity(builder.Configuration);

            builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();

            builder.Services.AddControllersWithViews(mvcOptions =>
            {
                mvcOptions.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
            });

            builder.Services.AddAplicationServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            await app.RunAsync();
        }
    }
}