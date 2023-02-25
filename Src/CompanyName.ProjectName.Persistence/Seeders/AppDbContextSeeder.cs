using CompanyName.ProjectName.Persistence.Contexts;

namespace CompanyName.ProjectName.Persistence.Seeders
{
    public class AppDbContextSeeder
    {        

        public void SeedEverything(AppDbContext db)
        { 
            db.Database.EnsureCreated();    
        }

        // Add your own seed methods 

    }
}
