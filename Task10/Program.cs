using Microsoft.EntityFrameworkCore;
using Task10.Configurations;
using Task10.Domain;
using Task10.Domain.Entities;

namespace Task10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Configuration.AddJsonFile("appsettings.json");
            Config config = new Config();
            builder.Configuration.Bind("Project", config);           
            builder.Services.AddLogging();
            builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(Config.ConnectionString));
            builder.Services.AddTransient<IEntityRepository<Investment>, EntityRepository<Investment>>();
            builder.Services.AddHttpClient();
            var app = builder.Build();

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
}
