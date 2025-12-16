using Lab07.models.movies;
using Microsoft.EntityFrameworkCore;

namespace Lab07;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
    
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<MoviesContext>();
        builder.Services.AddSingleton<Lab07.Models.IDateTimeProvider, Lab07.Models.CurrentDateTimeProvider>();
        builder.Services.AddSingleton<Lab07.Models.products.IProductService, Lab07.Models.products.MemoryProductService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}