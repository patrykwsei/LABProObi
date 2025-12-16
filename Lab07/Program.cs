using Data;
using Lab07.Models.products;
using Lab07.models.movies;
using Microsoft.EntityFrameworkCore;

namespace Lab07;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<MoviesContext>();

        var dbDir = Path.Combine(builder.Environment.ContentRootPath, "data");
        Directory.CreateDirectory(dbDir);
        var dbPath = Path.Combine(dbDir, "products.db");

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite($"Data Source={dbPath}"));

        builder.Services.AddTransient<IProductService, EFProductService>();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
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