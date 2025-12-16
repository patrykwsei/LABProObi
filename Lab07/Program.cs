using Data;
using Lab07.models.movies;
using Lab07.Models.products;
using Microsoft.EntityFrameworkCore;

namespace Lab07;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        // Movies (zostawiamy jak było)
        builder.Services.AddDbContext<MoviesContext>();

        // Products DB (SQLite) - baza products.db obok uruchamianej aplikacji
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("ProductsDb")));

        // Time provider
        builder.Services.AddSingleton<Lab07.Models.IDateTimeProvider, Lab07.Models.CurrentDateTimeProvider>();

        // Product service -> EF (nie Memory)
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