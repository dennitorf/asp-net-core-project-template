using CompanyName.ProjectName.Application.Common.Interfaces.Email;
using CompanyName.ProjectName.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.ProjectName.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEmailService, EmailService>();   

            return services;
        }
    }
}
