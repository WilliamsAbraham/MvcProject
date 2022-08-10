using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebData.Data;
using WebData.Data.Entities;

namespace MvcWebApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
          services.AddDbContext<WebAppContext>(opts =>
          opts.UseMySql(configuration.GetConnectionString("SqlConnection"), new MySqlServerVersion(new Version(8, 0, 11)), b => b.MigrationsAssembly("MvcWebApp")));

        public static void ConfigureIdentity(this IServiceCollection services) =>
            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<WebAppContext>()
            .AddDefaultTokenProviders();

    }
}
