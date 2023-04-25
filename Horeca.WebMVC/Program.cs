using Horeca.DataBaseLibrary.Data.Interfaces;
using Horeca.DataBaseLibrary.Data;
using Horeca.DataBaseLibrary.DataAcces;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Horeca.WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<ISqlDataAcces, SqlDataAcces>();
            builder.Services.AddTransient<IDaLocationDataService, DaLocationDataService>();
            builder.Services.AddTransient<IDaProductDataService, DaProductDataService>();
            builder.Services.AddTransient<IDaStockDataService, DaStockDataService>();
            builder.Services.AddTransient<IDaDepartmentDataService, DaDepartmentDataService>();
            builder.Services.AddTransient<IDaAuthentificationDataService, DaAuthentificationDataService>();
            builder.Services.AddTransient<IDaRecipeDataService, DaRecipeDataService>();
            builder.Services.AddTransient<IDaHistoryDataService, DaHistoryDataService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => x.LoginPath = "/Authentification/Login");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCookiePolicy();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Authentification}/{action=Login}/{id?}");

            app.Run();
        }
    }
}