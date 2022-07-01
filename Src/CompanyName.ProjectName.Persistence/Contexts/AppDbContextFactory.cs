using CompanyName.ProjectName.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CompanyName.ProjectName.Persistence.Contexts
{
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}
