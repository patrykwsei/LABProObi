using Data;
using Lab07.models.movies;
using Lab07.Models;
using Lab07.Models.products;
using Microsoft.EntityFrameworkCore;

namespace Lab07;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<MoviesContext>();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("ProductsDb")));

        builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();
        builder.Services.AddTransient<IProductService, EFProductService>();

        var app = builder.Build();

        // >>> TO DODANE: robi migracje automatycznie i zakłada tabele
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate();
        }
        // <<<

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}