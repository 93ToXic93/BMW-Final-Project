using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Services;
using BMW_Final_Project.Extensions;
using BMW_Final_Project.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace BMW_Final_Project
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAplicationDbContext(builder.Configuration);
            builder.Services.AddAplicationIdentity(builder.Configuration);
            builder.Services.AddApplicationAuthentication();

            builder.Services.AddControllersWithViews(mvcOptions =>
            {
                mvcOptions.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                mvcOptions.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            
            builder.Services.AddAplicationServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
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