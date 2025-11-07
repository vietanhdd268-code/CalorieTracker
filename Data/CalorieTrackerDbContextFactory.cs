using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CalorieTracker.Data
{
    public class CalorieTrackerDbContextFactory : IDesignTimeDbContextFactory<CalorieTrackerDbContext>
    {
        public CalorieTrackerDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CalorieTrackerDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new CalorieTrackerDbContext(optionsBuilder.Options);
        }
    }
}