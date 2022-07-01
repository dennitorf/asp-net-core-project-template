using CompanyName.ProjectName.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CompanyName.ProjectName.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = Environment.GetEnvironmentVariable("DatabaseConnectionString");
            connectionString = String.IsNullOrEmpty(connectionString) ? configuration.GetConnectionString("DatabaseConnectionString") : connectionString;

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("CompanyNameProjectName"); ;
                });
            }
            else
            {
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
                });
            }

            return services;
        }
    }
}
