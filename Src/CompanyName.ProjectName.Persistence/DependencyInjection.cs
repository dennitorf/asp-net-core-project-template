using CompanyName.ProjectName.Persistence.Contexts;
using Microsoft.Data.SqlClient;
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
                    options.UseSqlServer(GetConnectionString(configuration) , b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
                });
            }

            return services;
        }

        private static string GetConnectionString(IConfiguration configuration) 
        {
            string cs = "";

            if (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("DB_SERVER")) &&
                !String.IsNullOrEmpty(Environment.GetEnvironmentVariable("DB_USER")) &&
                !String.IsNullOrEmpty(Environment.GetEnvironmentVariable("DB_PASSWORD")) &&
                !String.IsNullOrEmpty(Environment.GetEnvironmentVariable("DB_DATABASE"))) 
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = Environment.GetEnvironmentVariable("DB_SERVER");
                builder.UserID = Environment.GetEnvironmentVariable("DB_USER");
                builder.Password = Environment.GetEnvironmentVariable("DB_PASSWORD");
                builder.InitialCatalog = Environment.GetEnvironmentVariable("DB_DATABASE");
                builder.MultipleActiveResultSets = true;
                builder.TrustServerCertificate = true;

                return builder.ConnectionString;
            }                
            else 
            {                                
                cs = configuration.GetConnectionString("DatabaseConnectionString");
            }

            Console.WriteLine($"CS: {cs}");

            return cs;
        }
    }
}
